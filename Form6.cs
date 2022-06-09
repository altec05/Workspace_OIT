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
using System.IO;
using System.ComponentModel;

namespace Work
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.Closing += Form2_Closing;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "СБИС-Онлайн", "АЦК-Финансы", "Закупки", "Busgov", "ГИС ГМП", "Поддержка 1С", "Честный знак" });
        }

        private void Form2_Closing(object sender, CancelEventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();

            switch (selectedState)
            {
                case "СБИС-Онлайн":

                    DialogResult result = MessageBox.Show("Открыть Онлайн СБИС?",
                "Запуск СБИС",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                string path = @"C:\Program Files (x86)\Tensor Company Ltd\SBIS3Plugin\sbis3plugin.exe";
                                string path_sbis = @"https://online.sbis.ru/";

                                System.Diagnostics.Process[] Procs = Process.GetProcessesByName("sbis3plugin");

                                if (Procs.Length > 2)
                                {
                                    try
                                    {
                                        MessageBox.Show("Пожалуйста, подождите...",
                                           "Запуск СБИС",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                           MessageBoxDefaultButton.Button1,
                                           MessageBoxOptions.DefaultDesktopOnly);

                                        Process.Start(path_sbis);
                                        this.Activate();
                                    }
                                    catch (Exception exp)
                                    {
                                        MessageBox.Show(exp.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("СБИС-Плагин не запущен!\nПытаемся запустить...");

                                    if (File.Exists(path) == true)
                                    {
                                        try
                                        {
                                            Process.Start(path);

                                            Procs = null;
                                            Procs = Process.GetProcessesByName("sbis3plugin");
                                            if (Procs.Length > 0)
                                            {
                                                Process.Start(path_sbis);
                                                this.Activate();
                                            }
                                        }
                                        catch (Exception exp)
                                        {
                                            MessageBox.Show(exp.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("СБИС-Плагин не найден!\nПереходим к открытию СБИС-Онлайн.");
                                        try
                                        {
                                            Process.Start(path_sbis);
                                            this.Activate();
                                        }
                                        catch (Exception exp)
                                        {
                                            MessageBox.Show(exp.Message);
                                        }
                                    }
                                }
                            }

                            break;

                        case DialogResult.No:
                            {
                                DialogResult result1 = MessageBox.Show("Запуск отменен.",
                                        "Запуск СБИС",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                                if (result1 == DialogResult.OK)
                                {
                                    this.Activate();
                                }
                            }

                            break;
                    }

                    break;

                case "АЦК-Финансы":
                    {
                        string path = @"https://azk.krasfin.ru/";

                        try
                        {
                            Process.Start(path);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }
                    break;

                case "Закупки":
                    {
                        string path = @"https://zakupki.gov.ru/epz/main/public/home.html";
                        string path_Yandex = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Yandex\YandexBrowser\Application\browser.exe";

                        if (File.Exists(path_Yandex) == true)
                        {
                            try
                            {
                                Process.Start(path_Yandex, path);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                Process.Start("IExplore.exe", path);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                    }
                    break;

                case "Busgov":
                    {
                        string path = @"https://bus.gov.ru/";

                        try
                        {
                            Process.Start(path);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }
                    break;

                case "ГИС ГМП":
                    {
                        string path = @"http://172.25.253.1:8082/";

                        Process[] Procs = Process.GetProcessesByName("AP_Mgr");

                        if (Procs.Length > 0)
                        {
                            MessageBox.Show("Континет-АП запущен.\nПроверьте чтобы значок Континент-АП в трее был зеленым! Иначе дважды нажмите по нему.");
                            try
                            {
                                Process.Start(path);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Континет-АП не запущен!\nПытаемся запустить...");

                            string path_VPN = @"C:\Program Files\Security Code\Terminal Station\vpn\AP_Mgr.exe";

                            if (File.Exists(path_VPN) == true)
                            {
                                try
                                {
                                    Process.Start(path_VPN);
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Континет-АП не найден!\nОбратитесь к администратору или запустите вручную.");
                            }
                        }
                    }
                    break;

                case "Поддержка 1С":
                    {
                        string path = @"http://sz.apogey.ru/sz/ru_RU/";

                        try
                        {
                            groupBox1.Visible = true;
                            label3.Visible = true;
                            label4.Visible = true;
                            textBox1.Visible = true;
                            textBox2.Visible = true;
                            textBox1.Text = "КрасноярскийКЦК№1";
                            textBox2.Text = "2465035105";
                            Process.Start(path);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }
                    break;
                case "Честный знак":
                    {
                        string path = @"https://mdlp.crpt.ru/#/auth/signin";

                        try
                        {
                            Process.Start(path);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                    }
                    break;

                default:
                    MessageBox.Show("Непредвиденная ошибка выбора.");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 newForm = new Form7();
            newForm.Show();
            Hide();
        }
    }
}
