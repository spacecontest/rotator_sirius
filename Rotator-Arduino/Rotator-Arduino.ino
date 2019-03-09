#include "BasicStepperDriver.h"
#include <avr/power.h>

// Константы 

#define STEPS                     200
#define MICROSTEPS_AZIMUTH        4
#define MICROSTEPS_ELEVATION      4

#define HOME_SPEED                120
#define AZIMUTH_MAX_SPEED         200
#define ELEVATION_MAX_SPEED       150
#define AZIMUTH_ACCEL_POSITIVE    2
#define AZIMUTH_ACCEL_NEGATIVE    0.25
#define ELEVATION_ACCEL_POSITIVE  1.5
#define ELEVATION_ACCEL_NEGATIVE  0.25

#define AZIMUTH_DIR               55
#define AZIMUTH_STEP              54
#define AZIMUTH_ENABLE            38
#define AZIMUTH_MIN               3

#define ELEVATION_DIR             61
#define ELEVATION_STEP            60
#define ELEVATION_ENABLE          56
#define ELEVATION_MIN             14 // Ось Y
//#define ELEVATION_MIN           18 // Ось Z

#define K                         90 // Итоговый коэффициент передачи редуктора

int AZIMUTH_ANGLE                 = 0;
int32_t AZIMUTH_TRACK             = 0;
int ELEVATION_ANGLE               = 0;
int32_t AZIMUTH_PAST_ENABLE       = 0;
int32_t ELEVATION_PAST_ENABLE     = 0;
int32_t PAST_COMM                 = 0;
bool COMM                         = false;
bool SLEEP_FLAG                   = false;
uint8_t COUNT_ZERO_POCKET         = 0;
String pocket                     = "";
bool worked                       = false;

BasicStepperDriver azimuth(STEPS, AZIMUTH_DIR, AZIMUTH_STEP, AZIMUTH_ENABLE);
BasicStepperDriver elevation(STEPS, ELEVATION_DIR, ELEVATION_STEP, ELEVATION_ENABLE);

void goWithAccelAzimuth(int angleR, int MAX_SPEED = AZIMUTH_MAX_SPEED, float ACCEL_POSITIVE = AZIMUTH_ACCEL_POSITIVE, float ACCEL_NEGATIVE = AZIMUTH_ACCEL_NEGATIVE);
void goWithAccelElevation(int angleR, int MAX_SPEED = ELEVATION_MAX_SPEED, float ACCEL_POSITIVE = ELEVATION_ACCEL_POSITIVE, float ACCEL_NEGATIVE = ELEVATION_ACCEL_NEGATIVE);

void setup() {
  Serial.begin(9600);
  
  pinMode(AZIMUTH_MIN, INPUT);
  pinMode(ELEVATION_MIN, INPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);

  azimuth.setMicrostep(MICROSTEPS_AZIMUTH);
  elevation.setMicrostep(MICROSTEPS_ELEVATION);

  // Проверка на обрыв провода концевика по азимуту
  if(!digitalRead(AZIMUTH_MIN)) {
    goWithAccelAzimuth(10);
    if(!digitalRead(AZIMUTH_MIN)) {
      azimuth.disable();
      while(true) {
        Serial.println("ERROR: azimuth end stop");
        digitalWrite(LED_BUILTIN, HIGH);
        delay(500);
        digitalWrite(LED_BUILTIN, LOW);
        delay(500);
      }
    }
  }

  azimuth.setRPM(HOME_SPEED);
  azimuth.enable();
  goWithAccelAzimuth(5);
  while(digitalRead(AZIMUTH_MIN)) azimuth.move(-1);
  azimuth.disable();

  // Проверка на обрыв провода концевика по элевации
  if(!digitalRead(ELEVATION_MIN)) {
    goWithAccelElevation(10);
    if(!digitalRead(ELEVATION_MIN)) {
      elevation.disable();
      while(true) {     
        Serial.println("ERROR: elevation end stop");
        digitalWrite(LED_BUILTIN, HIGH);
        delay(500);
        digitalWrite(LED_BUILTIN, LOW);
        delay(500);
      }
    }
  }

  elevation.setRPM(HOME_SPEED);
  elevation.enable();
  goWithAccelElevation(5);
  while(digitalRead(ELEVATION_MIN)) elevation.move(-1);
  elevation.disable();
  
  AZIMUTH_ANGLE   = 0;
  ELEVATION_ANGLE = 0;
  AZIMUTH_TRACK   = 0;

  // Сигнализируем о готовности к работе
  elevation.enable();
  azimuth.enable();
  delay(1000);
  elevation.disable();
  azimuth.disable();

  AZIMUTH_PAST_ENABLE   = millis();
  ELEVATION_PAST_ENABLE = millis();
  PAST_COMM             = millis();
  COMM                  = true;

  power_adc_disable();
  power_spi_disable();
  power_twi_disable();
}

void loop() {
  if(Serial.available()) {
    if(Serial.peek() != 0x0D) pocket += char(Serial.read());
    else {
      digitalWrite(LED_BUILTIN, HIGH);
      Serial.read();
      
      if(pocket.length() == 8 && pocket[0] == 'W') {
        if(!SLEEP_FLAG) COMM = true;
        worked = true;
        String AZIMUTH_ANGLE_STR = "", ELEVATION_ANGLE_STR = "";
        
        AZIMUTH_ANGLE_STR   += pocket[1];
        AZIMUTH_ANGLE_STR   += pocket[2];
        AZIMUTH_ANGLE_STR   += pocket[3];
        
        ELEVATION_ANGLE_STR += pocket[5];
        ELEVATION_ANGLE_STR += pocket[6];
        ELEVATION_ANGLE_STR += pocket[7];
        
        if(!SLEEP_FLAG) azimuth.enable();
        int AZIMUTH_ANGLE_R = AZIMUTH_ANGLE_STR.toInt();        
        AZIMUTH_ANGLE_R %= 360;

        if(!SLEEP_FLAG)
        {
          if(abs(AZIMUTH_ANGLE_R - AZIMUTH_ANGLE) < 180) goWithAccelAzimuth(AZIMUTH_ANGLE_R - AZIMUTH_ANGLE);
          else {
            if((AZIMUTH_ANGLE_R - AZIMUTH_ANGLE) < 0) goWithAccelAzimuth(360 + (AZIMUTH_ANGLE_R - AZIMUTH_ANGLE));
            else goWithAccelAzimuth(-1 * (360 - (AZIMUTH_ANGLE_R - AZIMUTH_ANGLE)));
          }
          AZIMUTH_ANGLE = AZIMUTH_ANGLE_R;
        }
               
        int ELEVATION_ANGLE_R = ELEVATION_ANGLE_STR.toInt();
        if(ELEVATION_ANGLE_R >= 90) ELEVATION_ANGLE_R = 90;
        if(ELEVATION_ANGLE_R - ELEVATION_ANGLE != 0 && !SLEEP_FLAG) {
          elevation.enable();
          goWithAccelElevation(ELEVATION_ANGLE_R - ELEVATION_ANGLE);
          ELEVATION_ANGLE = ELEVATION_ANGLE_R;
        }
        
        // Считаем пакеты с нулевым углом места для перехода в сон при работе с Orbitron'ом
        if(ELEVATION_ANGLE_R == 0) COUNT_ZERO_POCKET++;
        else {
          COUNT_ZERO_POCKET = 0;
          SLEEP_FLAG = false;
        }
        if(COUNT_ZERO_POCKET >= 10 && !SLEEP_FLAG) SLEEP_FLAG = true;
      }
      if(!SLEEP_FLAG) {
        AZIMUTH_PAST_ENABLE   = millis();
        ELEVATION_PAST_ENABLE = millis();
      }
      if(!SLEEP_FLAG && COMM) PAST_COMM = millis();

      digitalWrite(LED_BUILTIN, LOW);
      pocket = "";
    }
  }
  if(millis() - AZIMUTH_PAST_ENABLE >= 1000) azimuth.disable();
  if(millis() - ELEVATION_PAST_ENABLE >= 1000) elevation.disable();
  if((millis() - PAST_COMM >= 30000) && COMM && worked) {
    sleep();
    COMM = false;
  }
}

void HOME() {
  // Проверка на обрыв провода концевика по азимуту
  if(!digitalRead(AZIMUTH_MIN)) {
    goWithAccelAzimuth(10);
    if(!digitalRead(AZIMUTH_MIN)) {
      azimuth.disable();
      while(true) {
        Serial.println("ERROR: azimuth end stop");
        digitalWrite(LED_BUILTIN, HIGH);
        delay(500);
        digitalWrite(LED_BUILTIN, LOW);
        delay(500);
      }
    }
  }

  azimuth.setRPM(HOME_SPEED);
  azimuth.enable();
  goWithAccelAzimuth(5);
  while(digitalRead(AZIMUTH_MIN)) azimuth.move(-1);
  azimuth.disable();

  AZIMUTH_ANGLE = 0;
  
  // Проверка на обрыв провода концевика по элевации
  if(!digitalRead(ELEVATION_MIN)) {
    goWithAccelElevation(10);
    if(!digitalRead(ELEVATION_MIN)) {
      elevation.disable();
      while(true) {     
        Serial.println("ERROR: elevation end stop");
        digitalWrite(LED_BUILTIN, HIGH);
        delay(500);
        digitalWrite(LED_BUILTIN, LOW);
        delay(500);
      }
    }
  }

  elevation.setRPM(HOME_SPEED);
  elevation.enable();
  if(ELEVATION_ANGLE <= 85) goWithAccelElevation(5);
  while(digitalRead(ELEVATION_MIN)) elevation.move(-1);
  elevation.disable();

  ELEVATION_ANGLE = 0;
  
  // Сигнализируем о готовности к работе
  elevation.enable();
  azimuth.enable();
  delay(1000);
  elevation.disable();
  azimuth.disable();
}

void goWithAccelAzimuth(int angleR, int MAX_SPEED = AZIMUTH_MAX_SPEED, float ACCEL_POSITIVE = AZIMUTH_ACCEL_POSITIVE, float ACCEL_NEGATIVE = AZIMUTH_ACCEL_NEGATIVE) {
  int full       = angleR;
  AZIMUTH_TRACK += full;
  int znak       = 1;
  int angle      = full / 3;
  
  if(angle < 0) znak *= -1;
  
  int V = 50;
  
  for(int i = 0; i < abs(angle); ++i) {
    if(V <= MAX_SPEED) V += ACCEL_POSITIVE * i; // V += ACCEL_POSITIVE; для линейной зависимости
    azimuth.setRPM(V);
    azimuth.rotate(znak * K);
  }
  
  azimuth.rotate(K * ((full) - znak * 2 * abs(angle)));

  if(abs(angle) > 40) {
    azimuth.rotate(K * (angle - znak * 40));
    for(int i = 0; i < 40; ++i) {
      if(V >= 50) V -= ACCEL_NEGATIVE * i; // V -= ACCEL_NEGATIVE; для линейной зависимости
      azimuth.setRPM(V);
      azimuth.rotate(znak * K);
    }
  }
  else {
    for(int i = 0; i < abs(angle); ++i) {
      if(V >= 50) V -= ACCEL_NEGATIVE * i; // V -= ACCEL_NEGATIVE; для линейной зависимости
      azimuth.setRPM(V);
      azimuth.rotate(znak * K);
    }
  }
}

void goWithAccelElevation(int angleR, int MAX_SPEED = ELEVATION_MAX_SPEED, float ACCEL_POSITIVE = ELEVATION_ACCEL_POSITIVE, float ACCEL_NEGATIVE = ELEVATION_ACCEL_NEGATIVE)
{
  int full  = angleR;
  int znak  = 1;
  int angle = full / 3;
  
  if(angle < 0) znak *= -1;
  float V = 50;
  
  for(int i = 0; i < abs(angle); ++i) {
    if(V <= MAX_SPEED) V += ACCEL_POSITIVE * i; // V += ACCEL_POSITIVE; для линейной зависимости
    elevation.setRPM((int)V);
    elevation.rotate(znak * K);
  }
  
  elevation.rotate(K * ((full) - znak * 2 * abs(angle)));
  
  for(int i = 0; i < abs(angle); ++i) {
    if(V >= 50) V -= ACCEL_NEGATIVE * i; // V -= ACCEL_NEGATIVE; для линейной зависимости
    elevation.setRPM((int)V);
    elevation.rotate(znak * K);
  }
}

void sleep()
{
  SLEEP_FLAG    = true;
  AZIMUTH_TRACK = 0;
  azimuth.enable();
  goWithAccelAzimuth(-1 * AZIMUTH_TRACK);
  AZIMUTH_PAST_ENABLE = millis();
  delay(2500);
  HOME();
}
