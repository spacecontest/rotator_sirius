namespace RotatorGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AzimuthTextBox = new System.Windows.Forms.RichTextBox();
            this.AzimuthLabel = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.presetsListBox = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.serialSettings = new System.Windows.Forms.GroupBox();
            this.serialLog = new System.Windows.Forms.RichTextBox();
            this.serialConnect = new System.Windows.Forms.Button();
            this.serialSpeed = new System.Windows.Forms.NumericUpDown();
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.ElevationTextBox = new System.Windows.Forms.RichTextBox();
            this.ElevationLabel = new System.Windows.Forms.RichTextBox();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.serialSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.Controls.Add(this.AzimuthTextBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.AzimuthLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.presetsListBox, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.sendButton, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.resetButton, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.serialSettings, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.ElevationTextBox, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.ElevationLabel, 0, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(584, 261);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // AzimuthTextBox
            // 
            this.AzimuthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AzimuthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AzimuthTextBox.Font = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AzimuthTextBox.Location = new System.Drawing.Point(201, 53);
            this.AzimuthTextBox.Name = "AzimuthTextBox";
            this.AzimuthTextBox.Size = new System.Drawing.Size(186, 46);
            this.AzimuthTextBox.TabIndex = 17;
            this.AzimuthTextBox.Text = "Азимут";
            this.AzimuthTextBox.Resize += new System.EventHandler(this.AzimuthTextBox_Resize);
            // 
            // AzimuthLabel
            // 
            this.AzimuthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AzimuthLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AzimuthLabel.Font = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AzimuthLabel.Location = new System.Drawing.Point(3, 53);
            this.AzimuthLabel.Name = "AzimuthLabel";
            this.AzimuthLabel.ReadOnly = true;
            this.AzimuthLabel.Size = new System.Drawing.Size(192, 46);
            this.AzimuthLabel.TabIndex = 15;
            this.AzimuthLabel.Text = "Азимут";
            this.AzimuthLabel.Resize += new System.EventHandler(this.AzimuthLabel_Resize);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(393, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Предварительные ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(201, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ручное";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Последнее отправленное";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(201, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "управление ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(393, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "установки";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "значение";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // presetsListBox
            // 
            this.presetsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presetsListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.presetsListBox.FormattingEnabled = true;
            this.presetsListBox.Location = new System.Drawing.Point(393, 53);
            this.presetsListBox.Name = "presetsListBox";
            this.tableLayoutPanel.SetRowSpan(this.presetsListBox, 4);
            this.presetsListBox.Size = new System.Drawing.Size(188, 199);
            this.presetsListBox.TabIndex = 6;
            this.presetsListBox.SelectedIndexChanged += new System.EventHandler(this.presetsListBox_SelectedIndexChanged);
            this.presetsListBox.DoubleClick += new System.EventHandler(this.presetsListBox_DoubleClick);
            this.presetsListBox.Resize += new System.EventHandler(this.presetsListBox_Resize);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.Location = new System.Drawing.Point(201, 157);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(186, 46);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "Отправка команды";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            this.sendButton.Resize += new System.EventHandler(this.sendButton_Resize);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.Location = new System.Drawing.Point(201, 209);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(186, 49);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Перезагрузка контроллера";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            this.resetButton.Resize += new System.EventHandler(this.resetButton_Resize);
            // 
            // serialSettings
            // 
            this.serialSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialSettings.Controls.Add(this.serialLog);
            this.serialSettings.Controls.Add(this.serialConnect);
            this.serialSettings.Controls.Add(this.serialSpeed);
            this.serialSettings.Controls.Add(this.serialPorts);
            this.serialSettings.Location = new System.Drawing.Point(3, 157);
            this.serialSettings.Name = "serialSettings";
            this.tableLayoutPanel.SetRowSpan(this.serialSettings, 2);
            this.serialSettings.Size = new System.Drawing.Size(192, 101);
            this.serialSettings.TabIndex = 13;
            this.serialSettings.TabStop = false;
            this.serialSettings.Text = "Настройки COM-порта";
            // 
            // serialLog
            // 
            this.serialLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialLog.Location = new System.Drawing.Point(3, 75);
            this.serialLog.Name = "serialLog";
            this.serialLog.ReadOnly = true;
            this.serialLog.Size = new System.Drawing.Size(183, 20);
            this.serialLog.TabIndex = 3;
            this.serialLog.Text = "";
            // 
            // serialConnect
            // 
            this.serialConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialConnect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.serialConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serialConnect.Location = new System.Drawing.Point(131, 20);
            this.serialConnect.Name = "serialConnect";
            this.serialConnect.Size = new System.Drawing.Size(55, 48);
            this.serialConnect.TabIndex = 2;
            this.serialConnect.Text = "Подключить";
            this.serialConnect.UseVisualStyleBackColor = false;
            this.serialConnect.Click += new System.EventHandler(this.serialConnect_Click);
            this.serialConnect.Resize += new System.EventHandler(this.serialConnect_Resize);
            // 
            // serialSpeed
            // 
            this.serialSpeed.Location = new System.Drawing.Point(3, 48);
            this.serialSpeed.Maximum = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            this.serialSpeed.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.serialSpeed.Name = "serialSpeed";
            this.serialSpeed.Size = new System.Drawing.Size(121, 20);
            this.serialSpeed.TabIndex = 1;
            this.serialSpeed.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            // 
            // serialPorts
            // 
            this.serialPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(3, 20);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(121, 21);
            this.serialPorts.TabIndex = 0;
            this.serialPorts.SelectedIndexChanged += new System.EventHandler(this.serialPort_SelectedIndexChanged);
            this.serialPorts.Click += new System.EventHandler(this.serialPort_Click);
            // 
            // ElevationTextBox
            // 
            this.ElevationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElevationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElevationTextBox.Font = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElevationTextBox.Location = new System.Drawing.Point(201, 105);
            this.ElevationTextBox.Name = "ElevationTextBox";
            this.ElevationTextBox.Size = new System.Drawing.Size(186, 46);
            this.ElevationTextBox.TabIndex = 14;
            this.ElevationTextBox.Text = "Наклон";
            this.ElevationTextBox.Resize += new System.EventHandler(this.ElevationTextBox_Resize);
            // 
            // ElevationLabel
            // 
            this.ElevationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElevationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElevationLabel.Font = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElevationLabel.Location = new System.Drawing.Point(3, 105);
            this.ElevationLabel.Name = "ElevationLabel";
            this.ElevationLabel.ReadOnly = true;
            this.ElevationLabel.Size = new System.Drawing.Size(192, 46);
            this.ElevationLabel.TabIndex = 16;
            this.ElevationLabel.Text = "Наклон";
            this.ElevationLabel.Resize += new System.EventHandler(this.ElevationLabel_Resize);
            // 
            // serial
            // 
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainForm";
            this.Text = "SiriusRotator GUI";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.serialSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serialSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox presetsListBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox serialSettings;
        private System.Windows.Forms.RichTextBox AzimuthLabel;
        private System.Windows.Forms.RichTextBox ElevationLabel;
        private System.Windows.Forms.Button serialConnect;
        private System.Windows.Forms.NumericUpDown serialSpeed;
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.RichTextBox serialLog;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.RichTextBox AzimuthTextBox;
        private System.Windows.Forms.RichTextBox ElevationTextBox;
    }
}

