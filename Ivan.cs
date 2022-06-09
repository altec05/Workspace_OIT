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
using System.Net.Mail;
using System.Net;

namespace Work
{
    public partial class Ivan : Form
    {
        public Ivan()
        {
            InitializeComponent();
            this.Closing += Ivan_Closing;
        }

        private void Ivan_Closing(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("Closing Ivan");
            Form1 newForm1 = new Form1();
            newForm1.Show();
        }

        private void Ivan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.15.5\документы\АСУ\Иван Домашенко";

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
            string path = @"\\192.168.15.5\документы\АСУ\";

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

        private void button6_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.15.5\документы\АСУ\Иван Домашенко\РАБОТА";

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

        private void button5_Click(object sender, EventArgs e)
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
            string path = @"\\192.168.15.5\документы\АСУ\Ольга";

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

        private void button7_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.15.5\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы";

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

       
    }
}
