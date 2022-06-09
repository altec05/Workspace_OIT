using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Work
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.Closing += Form7_Closing;
        }

        private void Form7_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form6 newForm = new Form6();
            newForm.Show();
        }

        private string Path_NewProblems()
        {
            string path = @"Files\New\Soft";
            return path;
        }
   
        private void Send_Problem()
        {
            try
            {
                string str = richTextBox1.Text;
                int l = str.Length;

                if (l < 5)
                {
                    MessageBox.Show("Назовите и опишите интересующую вас программу или приложите ссылку",
                                "Ошибка создания новой записи",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                    this.Activate();
                }
                else
                {
                    //отправка лога на почту
                    MailAddress fromAddress = new MailAddress("ikdomashenko@kkck.ru", Environment.UserName);
                    MailAddress toAddress = new MailAddress("ikdomashenko@kkck.ru");
                    MailMessage message = new MailMessage(fromAddress, toAddress);
                    message.Body = richTextBox1.Text;
                    message.Subject = "New soft";
                    //message.IsBodyHtml = true;

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.yandex.ru";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("ikdomashenko@kkck.ru", "jcbxecaosrvjjmrl");

                    smtpClient.Send(message);

                    MessageBox.Show("Запрос отправлен!",
                                    "Создание нового запроса",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);

                    this.Activate();
                    this.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send_Problem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
