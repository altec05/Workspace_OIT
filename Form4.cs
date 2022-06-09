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
    public partial class Form4 : Form
    {
        string filename = "";

        public Form4()
        {
            InitializeComponent();
            this.Closing += Form4_Closing;
        }

        private void Form4_Closing(object sender, CancelEventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private string Path_NewProblems()
        {
            string path = @"Files\New\Problem\";
            return path;
        }

        private string Open_file()
        {
            

            OpenFileDialog opfd = new OpenFileDialog();

            opfd.CheckPathExists = true;
            opfd.CheckFileExists = true;
            opfd.DereferenceLinks = true;
            opfd.Multiselect = false;
            opfd.Title = "Выберите файл, который хотите прикрепить к сообщению";
            opfd.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Desktop";

            if (opfd.ShowDialog() == DialogResult.Cancel)
            {
                return "";
            }
            else
            {
                filename = opfd.FileName;
                return filename;
            }
        }

        private void Send_Problem(string filename)
        {
            try
            {
                string str = richTextBox1.Text;
                int l = str.Length;

                if (l < 5)
                {
                    MessageBox.Show("Опишите вашу проблему!",
                                "Ошибка создания нового запроса",
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
                    message.Subject = "New problem";
                    //message.IsBodyHtml = true;
                    if(filename == "")
                    {

                    }
                    else
                    {
                        message.Attachments.Add(new Attachment(filename));
                    }
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
            Send_Problem(filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open_file();
        }
    }
}
