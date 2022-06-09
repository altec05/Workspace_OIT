using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;



namespace Work
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            this.Closing += Form1_Closing;
        }

        public bool GetDomainName()
        {
            // if No domain name return a generic string           
            string currentDomainName = IPGlobalProperties.GetIPGlobalProperties().DomainName ?? "nodomainname";
            bool check_domain;

            if (currentDomainName.ToLower() == "kkck.loc")
            {
                check_domain = true;
            }
            else
            {
                check_domain = false;
            }

            return check_domain;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Activate();

            button6.Visible = false;

            if(GetDomainName() == false)
            {
                groupBox1.Visible = false;
            }

            if (Environment.UserName == "domashenkoik")
            {
                button6.Visible = true;
            }
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.15.5\документы\АСУ\Иван Домашенко\Инструкции";

            try
            {
                // Запускаем нужный файл
                Process.Start(path);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.15.4\Soft";

            try
            {
                // Запускаем нужный файл
                Process.Start(path);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            string path = @"\\192.168.15.5\scaner\OIT192.168.14.9";

            try
            {
                // Запускаем нужный файл
                Process.Start(path);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 Sites = new Form6();
            Sites.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ivan newForm = new Ivan();
            newForm.Show();
            Hide();
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "::{2227A280-3AEA-1069-A2DE-08002B30309D}";
            Process.Start(startInfo);
        }
    }
}
