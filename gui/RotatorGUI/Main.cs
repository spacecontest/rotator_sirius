using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotatorGUI
{
    public partial class MainForm : Form
    {
        public bool connected = false;

        public MainForm()
        {
            InitializeComponent();

            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"presets.txt");
                while ((line = file.ReadLine()) != null)
                {
                    presetsListBox.Items.Add(line);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                serialLog.AppendText("Ошибка: " + ex.Message + "\n");
                serialLog.ScrollToCaret();
            }


            serialPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                serialPorts.Items.Add(ports[i]);
            }
        }

        private void presetsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = presetsListBox.Text;
            string[] temp2 = temp.Split(' ');

            AzimuthTextBox.Text = temp2[0];
            ElevationTextBox.Text = temp2[1];
        }

        private void serialPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serialPort_Click(object sender, EventArgs e)
        {
            serialPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                serialPorts.Items.Add(ports[i]);
            }
        }

        private void serialConnect_Click(object sender, EventArgs e)
        {
            
            if (!connected)
            {
                try
                {
                    serial.PortName = serialPorts.Text;
                    serial.BaudRate = (int)serialSpeed.Value;
                    serial.Open();
                    connected = true;
                    
                    serialLog.AppendText("Порт открыт" + "\n");
                    serialLog.ScrollToCaret();
                    serialConnect.Text = "Отключить";
                    serialPorts.Enabled = false;
                    serialSpeed.Enabled = false;
                }
                catch (Exception ex)
                {
                    serialLog.AppendText("Ошибка: " + ex.Message + "\n");
                    serialLog.ScrollToCaret();
                    return;
                }
            }
            else
            {
                try
                {
                    serial.Close();
                }
                catch (Exception ex)
                {
                    serialLog.AppendText("Ошибка: " + ex.Message + "\n");
                    serialLog.ScrollToCaret();
                    return;
                }

                connected = false;
                serialLog.AppendText("Порт закрыт" + "\n");
                serialLog.ScrollToCaret();
                serialConnect.Text = "Подключить";
                serialPorts.Enabled = true;
                serialSpeed.Enabled = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                //char[] buf = new char[9];
                string buf;

                int az = Int32.Parse(AzimuthTextBox.Text);
                int el = Int32.Parse(ElevationTextBox.Text);

                az %= 1000;
                buf = "W" + (az / 100).ToString();
                az %= 100;
                buf += (az / 10).ToString();
                az %= 10;
                buf += az.ToString();
                buf += " 0";

                el %= 100;
                buf += (el / 10).ToString();
                el %= 10;
                buf += el.ToString();
                buf += ((char) 0x0D).ToString();

                if (connected)
                {
                    serial.Write(buf);
                    serialLog.Invoke((MethodInvoker)delegate
                    {
                        serialLog.AppendText("RotatorGUI @ PC: " + buf + "\n");
                        serialLog.ScrollToCaret();
                    });

                    AzimuthLabel.Text = AzimuthTextBox.Text;
                    ElevationLabel.Text = ElevationTextBox.Text;
                }
            }
            catch (Exception ex)
            {
                serialLog.AppendText("Ошибка: " + ex.Message + "\n");
                serialLog.ScrollToCaret();
                return;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (connected) {
                serial.DtrEnable = true;
                serial.DtrEnable = false;

                serialLog.AppendText("Перезагрузка контроллера" + "\n");
                serialLog.ScrollToCaret();
            }
        }

        private void presetsListBox_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                string temp = presetsListBox.Text;
                string[] temp2 = temp.Split(' ');

                AzimuthTextBox.Text = temp2[0];
                ElevationTextBox.Text = temp2[1];

                //char[] buf = new char[9];
                string buf;

                int az = Int32.Parse(AzimuthTextBox.Text);
                int el = Int32.Parse(ElevationTextBox.Text);

                az %= 1000;
                buf = "W" + (az / 100).ToString();
                az %= 100;
                buf += (az / 10).ToString();
                az %= 10;
                buf += az.ToString();
                buf += " 0";

                el %= 100;
                buf += (el / 10).ToString();
                el %= 10;
                buf += el.ToString();
                buf += ((char)0x0D).ToString();

                if (connected)
                {
                    serial.Write(buf);
                    serialLog.Invoke((MethodInvoker)delegate
                    {
                        serialLog.AppendText("RotatorGUI @ PC: " + buf + "\n");
                        serialLog.ScrollToCaret();
                    });

                    AzimuthLabel.Text = AzimuthTextBox.Text;
                    ElevationLabel.Text = ElevationTextBox.Text;
                }
            }
            catch (Exception ex)
            {
                serialLog.AppendText("Ошибка: " + ex.Message + "\n");
                serialLog.ScrollToCaret();
                return;
            }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialLog.AppendText("Устройство @ " + serial.PortName + ": " + serial.ReadExisting() + "\n");
            serialLog.ScrollToCaret();
        }

        private void AzimuthLabel_Resize(object sender, EventArgs e)
        {
            if (AzimuthLabel.Height > 100) { AzimuthLabel.Font = new Font("Courier New", 70); }
            else if (AzimuthLabel.Height < 100) { AzimuthLabel.Font = new Font("Courier New", 28); }
        }

        private void ElevationLabel_Resize(object sender, EventArgs e)
        {
            if (ElevationLabel.Height > 100) { ElevationLabel.Font = new Font("Courier New", 70); }
            else if (ElevationLabel.Height < 100) { ElevationLabel.Font = new Font("Courier New", 28); }
        }

        private void AzimuthTextBox_Resize(object sender, EventArgs e)
        {
            if (AzimuthTextBox.Height > 100) { AzimuthTextBox.Font = new Font("Courier New", 70); }
            else if (AzimuthTextBox.Height < 100) { AzimuthTextBox.Font = new Font("Courier New", 28); }
        }

        private void ElevationTextBox_Resize(object sender, EventArgs e)
        {
            if (ElevationTextBox.Height > 100) { ElevationTextBox.Font = new Font("Courier New", 70); }
            else if (ElevationTextBox.Height < 100) { ElevationTextBox.Font = new Font("Courier New", 28); }
        }

        private void sendButton_Resize(object sender, EventArgs e)
        {
            if (sendButton.Height > 100) { sendButton.Font = new Font("Microsoft Sans Serif", 22); }
            else if (sendButton.Height < 100) { sendButton.Font = new Font("Microsoft Sans Serif", 8); }
        }

        private void resetButton_Resize(object sender, EventArgs e)
        {
            if (resetButton.Height > 100) { resetButton.Font = new Font("Microsoft Sans Serif", 22); }
            else if (resetButton.Height < 100) { resetButton.Font = new Font("Microsoft Sans Serif", 8); }
        }

        private void serialConnect_Resize(object sender, EventArgs e)
        {
            if (serialConnect.Width > 150) { serialConnect.Font = new Font("Microsoft Sans Serif", 16); }
            else if (serialConnect.Width < 150) { serialConnect.Font = new Font("Microsoft Sans Serif", 8); }
        }

        private void presetsListBox_Resize(object sender, EventArgs e)
        {
            if (presetsListBox.Height > 300) { presetsListBox.Font = new Font("Microsoft Sans Serif", 16); }
            else if (presetsListBox.Height < 300) { presetsListBox.Font = new Font("Microsoft Sans Serif", 8); }
        } 
    }
}
