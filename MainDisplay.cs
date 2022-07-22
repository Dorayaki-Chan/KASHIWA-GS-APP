using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GSApp1
{
    public partial class KASHIWA : Form
    {
        delegate void SetTextCallback(string text);
        Logger log = Logger.GetInstance();
        HandleCSV csvData = new HandleCSV();

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
            
            try
            {
                
                foreach (string i in command)
                {

                    //Console.WriteLine(i);
                    byte[] array = new byte[1];
                    array[0] = Convert.ToByte(i, 16);
                    //Console.WriteLine(i);
                    //Console.WriteLine(array[0]);
                    //Console.WriteLine(array);
                    serialPort1.Write(array, 0, 1);
                    await Task.Delay(250);
                    count++;
                }
                string str = "送信:[" + Sending_command + "]";
                log.Info(str);
                Console.Write("カウント{0}\n", count);
                
                //serialPort1.Write(tbxTxData.Text);
                //確認用
                /*
                byte[] array = new byte[14];
                array[0] = 0x01;
                array[1] = 0x02;
                array[2] = 0x03;
                array[3] = 0x01;
                array[4] = 0x02;
                array[5] = 0x03;
                array[6] = 0x01;
                array[7] = 0x02;
                array[8] = 0x03;
                array[9] = 0x01;
                array[10] = 0x02;
                array[11] = 0x03;
                array[12] = 0x02;
                array[13] = 0x03;
                serialPort1.Write(array, 0, 1);
                */
                await Task.Delay(250);
                
            }
            catch
            {
                btnClode_Click(this, null);
            }
            btnSend.Enabled = true;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("反応！");
            string strDataReceived = "";
            byte[] buf = new byte[serialPort1.BytesToRead];
            try
            {
                //Console.WriteLine(buf.Length);
                serialPort1.Read(buf, 0, buf.Length);
                //Console.WriteLine("BytesToRead {0}", serialPort1.BytesToRead);
                //Console.WriteLine("ReadByte {0}", serialPort1.ReadByte());
                //Console.WriteLine("ReadExisting {0}", serialPort1.ReadExisting());
                Console.WriteLine("{0}\n\n", BitConverter.ToString(buf));
                strDataReceived = BitConverter.ToString(buf) + "\r\n";
                SetText(strDataReceived);
                string str = "受信:[" + BitConverter.ToString(buf) + "]";
                log.Info(str);
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

        private void telCmdListReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
                csvData.readCSV(openFileDialog1.FileName);
            }
        }

    }
}
