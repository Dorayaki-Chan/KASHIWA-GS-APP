using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GSApp1
{
    public partial class KASHIWA : Form
    {
        delegate void SetTextCallback(string text);

        public KASHIWA()
        {
            InitializeComponent();
            scanCOMPorts();
            cmbBaud.SelectedIndex = 3; //初期値は9600
        }
        private void scanCOMPorts()
        {
            cmbCOMPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cmbCOMPort.Items.Add(p);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnClode_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true; //接続表示ON
            btnClode.Enabled = false; //切断表示OFF
            btnScan.Enabled = true; //交信表示ON
            cmbCOMPort.Enabled = true; //COMリストON
            cmbBaud.Enabled = true; //cmbラジオON
            btnSend.Enabled = false; //送信OFF

            try
            {
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Close();
            }
            catch { };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxRxData.Clear();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            scanCOMPorts();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbCOMPort.Text; //COM名設定
                serialPort1.BaudRate = int.Parse(cmbBaud.Text);
                serialPort1.Open();　//ポート接続
                btnOpen.Enabled = false; //接続表示OFF
                btnClode.Enabled = true; //切断表示ON
                btnScan.Enabled = false; //交信表示OFF
                cmbCOMPort.Enabled = false; //COMリストOFF
                cmbBaud.Enabled = false; //cmbラジオOFF
                btnSend.Enabled = true; //送信ON
                tbxRxData.Clear(); //画面クリア
                tbxRxData.AppendText("Connected\r\n"); //接続と表示
            }
            catch
            {
                btnClode_Click(this, null); //切断ボタンを押す
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            string Sending_command = tbxTxData.Text;
            // 16進数に変換(多分)
            //byte[] packet = Sending_command.ToString().Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();
            string[] command = Sending_command.ToString().Split(' ');
            int count = 0;
            foreach (string i in command)
            {
                Console.WriteLine(i);
                //Console.WriteLine(i);
                byte[] array = new byte[1];
                array[0] = ;
                //Console.WriteLine(array);
                serialPort1.Write(array, 0, 1);
                await Task.Delay(1000);
                count++;
            }
            Console.Write("カウント{0}\n", count);
            try
            {
                
                
                //serialPort1.Write(tbxTxData.Text);
                if (rbCRLF.Checked) serialPort1.Write("\r\n");
                if (rbLF.Checked) serialPort1.Write("\n");
                
            }
            catch
            {
                btnClode_Click(this, null);
            }
            btnSend.Enabled = true;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Console.WriteLine("BytesToRead {0}", serialPort1.BytesToRead);
                Console.WriteLine("ReadByte {0}", serialPort1.ReadByte());
                Console.WriteLine("ReadExisting {0}", serialPort1.ReadExisting());
                Console.WriteLine("\n\n");
                SetText(serialPort1.ReadExisting());
            }
            catch
            {
                btnClode_Click(this, null);
            }
        }
        private void SetText(string text)
        {
            if (tbxRxData.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                tbxRxData.AppendText(text);
            }
        }

        private void tbxRxData_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxTxData_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
