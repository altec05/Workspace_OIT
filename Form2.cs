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

namespace Work
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Closing += Form2_Closing;
        }

        private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Континент-АП", "СТЭК-Траст", "Закупки - Настройка рабочего места", "АЦК - плагин устарел", "Установить корневые сертификаты для ЭП", });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedState = comboBox1.SelectedItem.ToString();

            switch (selectedState)
            {
                case "Континент-АП":
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\Континент-АП");

                    try
                    {
                        Process.Start(path1);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    break;

                case "СТЭК-Траст":
                    string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\СТЭК-траст");
                    try
                    {
                        // Запускаем нужный файл
                        Process.Start(path2);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    break;

                case "Закупки - Настройка рабочего места":
                    string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\СКЗИ\ЕИС");
                    try
                    {
                        // Запускаем нужный файл
                        Process.Start(path3);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    break;

                case "АЦК - плагин устарел":
                    DialogResult result = MessageBox.Show("Перейти к скачиванию актуальной версии плагина?",
                   "Переход по внешней ссылке",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                string path4 = @"http://minfin.krskstate.ru/dat/bin/art/19456_instrukcii_1.0.4.4.rar";
                                try
                                {
                                    // Запускаем нужный файл
                                    Process.Start(path4);
                                    this.Activate();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message);
                                }
                            }
                            break;

                        case DialogResult.No:
                            {
                                DialogResult result1 = MessageBox.Show("Скачивание отменено.",
                                        "Переход по внешней ссылке",
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

                case "Установить корневые сертификаты для ЭП":
                    string path_certmgr1 = @"C:\Program Files\Crypto Pro\CSP\certmgr.exe";
                    string path_certmgr2 = @"C:\Program Files(x86)\Crypto Pro\CSP\certmgr.exe";
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\СКЗИ\ЕИС\Certs\certs.bat");


                   DialogResult result2 = MessageBox.Show("Будет произведена установка корневых сертификатов.\nЖелаете продолжить?",
                   "Установка корневых сертификатов",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);

                    switch (result2)
                    {
                        case DialogResult.Yes:
                            {
                                if (File.Exists(path_certmgr1) == true)
                                {
                                    try
                                    {
                                        ProcessStartInfo info = new ProcessStartInfo(path);
                                        info.Arguments = @"C:\Program" + @" Files\Crypto" + @" Pro\CSP\certmgr.exe";
                                        System.Diagnostics.Process.Start(info);
                                        this.Activate();
                                    }
                                    catch (Exception exp)
                                    {
                                        MessageBox.Show(exp.Message);
                                    }
                                }
                                else
                                {
                                    if (File.Exists(path_certmgr2) == true)
                                    {
                                        try
                                        {
                                            ProcessStartInfo info = new ProcessStartInfo(path);
                                            info.Arguments = @"C:\Program" + @" Files(x86)\Crypto" + @" Pro\CSP\certmgr.exe";
                                            System.Diagnostics.Process.Start(info);
                                            this.Activate();
                                        }
                                        catch (Exception exp)
                                        {
                                            MessageBox.Show(exp.Message);
                                        }
                                    }
                                    else
                                    {
                                        {
                                            DialogResult result3 = MessageBox.Show("На устройстве отсутствует криптопровайдер.\nЖелаете провести его установку?",
                                               "Установка корневых сертификатов",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button1,
                                               MessageBoxOptions.DefaultDesktopOnly);

                                            switch (result3)
                                            {
                                                case DialogResult.Yes:
                                                    {
                                                        string path4 = @"Files\СКЗИ\КриптоПРО CSP";
                                                        try
                                                        {
                                                            Process.Start(path4);
                                                            this.Activate();
                                                        }
                                                        catch (Exception exp)
                                                        {
                                                            MessageBox.Show(exp.Message);
                                                        }
                                                    }

                                                    break;

                                                case DialogResult.No:
                                                    {
                                                        DialogResult result4 = MessageBox.Show("Установка отменена.",
                                                                "Установка криптопровайдера",
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Information,
                                                                MessageBoxDefaultButton.Button1,
                                                                MessageBoxOptions.DefaultDesktopOnly);
                                                        if (result4 == DialogResult.OK)
                                                        {
                                                            this.Activate();
                                                        }
                                                    }

                                                    break;
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        case DialogResult.No:
                            {
                                DialogResult result1 = MessageBox.Show("Установка отменена.",
                                        "Установка корневых сертификатов",
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

                default:
                    MessageBox.Show("Ошибка выбора.");
                    break;
            }

         }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
