namespace VoiceChat_Server
{
    partial class VoiceChat_Server
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.listBox_Status = new System.Windows.Forms.ListBox();
            this.button_StartServer = new System.Windows.Forms.Button();
            this.button_Default = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Порт";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(60, 13);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 20);
            this.textBox_Port.TabIndex = 1;
            this.textBox_Port.Text = "8080";
            this.textBox_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Port_KeyPress);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Disconnect.Location = new System.Drawing.Point(272, 8);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(100, 62);
            this.button_Disconnect.TabIndex = 3;
            this.button_Disconnect.Text = "Отключить";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // listBox_Status
            // 
            this.listBox_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Status.FormattingEnabled = true;
            this.listBox_Status.ItemHeight = 15;
            this.listBox_Status.Location = new System.Drawing.Point(16, 76);
            this.listBox_Status.Name = "listBox_Status";
            this.listBox_Status.Size = new System.Drawing.Size(356, 169);
            this.listBox_Status.TabIndex = 4;
            // 
            // button_StartServer
            // 
            this.button_StartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_StartServer.Location = new System.Drawing.Point(166, 8);
            this.button_StartServer.Name = "button_StartServer";
            this.button_StartServer.Size = new System.Drawing.Size(100, 62);
            this.button_StartServer.TabIndex = 5;
            this.button_StartServer.Text = "Запустить Сервер";
            this.button_StartServer.UseVisualStyleBackColor = true;
            this.button_StartServer.Click += new System.EventHandler(this.button_StartServer_Click);
            // 
            // button_Default
            // 
            this.button_Default.Location = new System.Drawing.Point(60, 39);
            this.button_Default.Name = "button_Default";
            this.button_Default.Size = new System.Drawing.Size(100, 31);
            this.button_Default.TabIndex = 6;
            this.button_Default.Text = "По умолчанию";
            this.button_Default.UseVisualStyleBackColor = true;
            this.button_Default.Click += new System.EventHandler(this.button_Default_Click);
            // 
            // VoiceChat_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.button_Default);
            this.Controls.Add(this.button_StartServer);
            this.Controls.Add(this.listBox_Status);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VoiceChat_Server";
            this.Text = "Form_ChatServer";
            this.Load += new System.EventHandler(this.VoiceChat_Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.ListBox listBox_Status;
        private System.Windows.Forms.Button button_StartServer;
        private System.Windows.Forms.Button button_Default;
    }
}

