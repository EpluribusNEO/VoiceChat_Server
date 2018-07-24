using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Net;

namespace VoiceChat_Server
{
    public partial class VoiceChat_Server : Form
    {
        public void ShowMessage(string msg)
        {
            listBox_Status.Items.Add(msg);
            listBox_Status.SelectedIndex = listBox_Status.Items.Count - 1;
        }
        public VoiceChat_Server()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ToolTip tl = new ToolTip();
            tl.SetToolTip(button_Default, "Задать номер порта используемый по умолчанию.");
        }

        private void button_StartServer_Click(object sender, EventArgs e)
        {
            string msg = SocketCoder.SockCoderBinServer.StartServer(int.Parse(textBox_Port.Text));
            ShowMessage(msg);
            button_StartServer.Enabled = false;
            button_Disconnect.Enabled = true;
            textBox_Port.Enabled = false;
            button_Default.Enabled = false;
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = SocketCoder.SockCoderBinServer.Disconnection();
                ShowMessage(msg);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            button_Disconnect.Enabled = false;
            button_StartServer.Enabled = true;
            textBox_Port.Enabled = true;

            button_Default.Enabled = true;
        }

        private void textBox_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }

        private void VoiceChat_Server_Load(object sender, EventArgs e)
        {
            string strMsg = "IP этого ПК " + GetLocalIP();
            ShowMessage(strMsg);
        }

        private void button_Default_Click(object sender, EventArgs e)
        {
            textBox_Port.Text = string.Empty;
            textBox_Port.Text = "8080";
        }

        private string GetLocalIP()
        {
            String strHostName = String.Empty;
            strHostName = Dns.GetHostName();
            string strIP = string.Empty;

            IPHostEntry IPthisPc = Dns.GetHostByName(strHostName);
            IPAddress[] addr = IPthisPc.AddressList;
            for (int i = 0; i < addr.Length; i++)
                strIP += addr[i].ToString() + " ";

            return strIP;
        }
    }
}
