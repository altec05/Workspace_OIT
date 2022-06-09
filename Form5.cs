using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;

namespace Work
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.Closing += Form5_Closing;
        }

        private void Form5_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CheckNetwork();
        }

        public void Ping_them(string address)
        {
            try
            {
                if(address == "")
                {
                    MessageBox.Show("Проверьте введенный адрес!",
                                    "Ошибка запроса",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    this.Activate();
                }
                else
                {
                    Ping png = new Ping();
                    PingReply replict = png.Send(address);
                    if (replict.Status == IPStatus.Success)
                    {
                        MessageBox.Show("Ping -" + address + "- OK\n" + "Задержка " + replict.RoundtripTime + " ms");
                    }
                    else
                    {
                        MessageBox.Show("Ping Fail");
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        public void CheckNetwork()
        {
            List<string> Net_Interfaces = new List<string>();
            List<string> Net_Interfaces_Type = new List<string>();

            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                NetworkInterface[] interfacesList = NetworkInterface.GetAllNetworkInterfaces();

                for (int i = 0; i < interfacesList.Length; i++)
                {
                    if ((interfacesList[i].NetworkInterfaceType.ToString().Contains("Ethernet") && interfacesList[i].OperationalStatus.ToString().Contains("Up"))
                        || (interfacesList[i].NetworkInterfaceType.ToString().Contains("Wireless") && interfacesList[i].OperationalStatus.ToString().Contains("Up")))
                    {
                        Net_Interfaces.Add(interfacesList[i].Description.ToString());
                        Net_Interfaces_Type.Add(interfacesList[i].NetworkInterfaceType.ToString());

                    }
                }
                String host = Dns.GetHostName();
                IPAddress ip = Dns.GetHostByName(host).AddressList[0];

                MessageBox.Show("Сетевое подключение доступно!");
                label2.Text = "Адаптер: " + Net_Interfaces[0];
                label3.Text = "IP-адрес: " + ip.ToString();
                label4.Text = "Тип: " + Net_Interfaces_Type[0];
            }
            else
            {
                NetworkInterface[] interfacesList = NetworkInterface.GetAllNetworkInterfaces();

                for (int i = 0; i < interfacesList.Length; i++)
                {
                    if (interfacesList[i].NetworkInterfaceType.ToString() == "Ethernet")
                    {
                        Net_Interfaces.Add(interfacesList[i].Description.ToString());
                    }
                }

                MessageBox.Show("Сетевое подключение отсутствует!\nАдаптер: " + Net_Interfaces[0]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping_them(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ping_them("192.168.15.5");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ping_them("Google.com");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "::{7007ACC7-3202-11D1-AAD2-00805FC1270E}";
            Process.Start(startInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String host = Dns.GetHostName();
            IPAddress ip = Dns.GetHostByName(host).AddressList[0];
            if (ip.ToString().Contains("192.168") == true)
            {
                Ping_them("192.168.50.2");
            }
            else
            {
                if (ip.ToString().Contains("10.204") == true)
                {
                    Ping_them("10.204.0.4");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
