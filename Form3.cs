using System;
using System.Windows.Forms;
using System.Net;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Work
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Closing += Form3_Closing;
        }

        WebClient Client_V = new WebClient();
        WebClient Client_Z = new WebClient();

        private void Form3_Closing(object sender, CancelEventArgs e)
        {
            Clear_wc();
            Del_NewVersionFiles();
            Application.Exit();
        }

        private void Clear_wc()
        {
            Client_V.CancelAsync();
            Client_V.Dispose();

            Client_Z.CancelAsync();
            Client_Z.Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Check_newPatch();
            Del_all_downloads();
            label3.Text = "Версия приложения: " + GetReg_Version() + "\nИмя пользователя: " + Environment.UserName.ToUpper() + "\nДомен: " + Environment.UserDomainName;
        }

        private string UpdateZip_path()
        {
            string Update_path = @"C:\Users\" + Environment.UserName + @"\Downloads\Update.zip";
            //string Update_path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Update.zip";
            return Update_path;
        }

        private string Version_path()
        {
            //string vpath =  $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\actual_version.txt";
            string vpath = @"C:\Users\" + Environment.UserName + @"\Downloads\actual_version.txt";
            return vpath;
        }

        private string Update_File()
        {
            string file = FromZip_toPath() + @"Update.exe";
            return file;
        }

        private string Uninstall_File()
        {
            string file = FromZip_toPath() + @"Uninstall.exe";
            return file;
        }

        private string Uninstall_ini_File()
        {
            string file = FromZip_toPath() + @"Uninstall.ini";
            return file;
        }

        private string Update_bat()
        {
            string file = FromZip_toPath() + @"Update.bat";
            return file;
        }


        private string FromZip_toPath()
        {
            //string vpath =  $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\actual_version.txt";
            string z_path = @"C:\Users\" + Environment.UserName + @"\Downloads\";
            return z_path;
        }

        private void Check_newPatch()
        {
            FileInfo updatefileinfo = new FileInfo(Update_File()); //извлеченный установочник

            if (updatefileinfo.Exists)
            {
                DateTime TimeOfCreation = (File.GetCreationTime(updatefileinfo.ToString()));
                TimeSpan time1 = TimeOfCreation.TimeOfDay;
                TimeSpan time2 = DateTime.Now.TimeOfDay;
                TimeSpan check1 = time2 - time1;
                TimeSpan check2 = new TimeSpan (1, 00, 00);
                if (TimeOfCreation.Day == DateTime.Now.Day && TimeOfCreation.Month == DateTime.Now.Month)
                {
                    if(check1 < check2)
                    {
                        DialogResult = MessageBox.Show("Открыть описание изменений после обновления?",
                        "Успешное обновление",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        if (DialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                Process.Start(@"Files\Patch Notes.txt");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
        }

        private void Del_all_downloads()
        {
            FileInfo versionfileinfo = new FileInfo(Version_path()); //версия
            FileInfo updatezipfileinfo = new FileInfo(UpdateZip_path()); //скаченный архив
            FileInfo updatefileinfo = new FileInfo(Update_File()); //извлеченный установочник
            FileInfo uninstallfileinfo = new FileInfo(Uninstall_File());
            FileInfo uninstall_inifileinfo = new FileInfo(Uninstall_ini_File());
            FileInfo update_batinfo = new FileInfo(Update_bat());

            if (versionfileinfo.Exists)
            {
                versionfileinfo.Delete();
            }

            if (updatezipfileinfo.Exists)
            {
                updatezipfileinfo.Delete();
            }

            if (updatefileinfo.Exists)
            {
                updatefileinfo.Delete();
            }

            if (uninstallfileinfo.Exists)
            {
                uninstallfileinfo.Delete();
            }

            if (uninstall_inifileinfo.Exists)
            {
                uninstall_inifileinfo.Delete();
            }

            if (update_batinfo.Exists)
            {
                update_batinfo.Delete();
            }
        }

        private void Del_NewVersionFiles()
        {
            FileInfo versionfileinfo = new FileInfo(Version_path()); //версия
            FileInfo updatezipfileinfo = new FileInfo(UpdateZip_path()); //скаченный архив

            if (versionfileinfo.Exists)
            {
                versionfileinfo.Delete();
            }

            if (updatezipfileinfo.Exists)
            {
                updatezipfileinfo.Delete();
            }
        }

        private bool Check_Version()
        {
            bool check = false;

            GetReg_Version();
            Read_Version();

            if ((Read_Version() != null) && GetReg_Version() != null)
            {
                if (GetReg_Version() != Read_Version())
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }

            return check;
        }

        private string GetReg_Version()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\");
            string[] skeys = key.GetSubKeyNames();
            string DisplayName = null;
            string DisplayVersion = null;

            for (int i = 0; i < skeys.Length; i++)
            {
                RegistryKey appKey = key.OpenSubKey(skeys[i]);
                try
                {
                    if (appKey.GetValue("DisplayName") != null)
                    {
                        DisplayName = appKey.GetValue("DisplayName").ToString();

                        if (DisplayName.ToLower().Contains("workspace oit"))
                        {
                            if (appKey.GetValue("DisplayVersion") != null)
                            {
                                DisplayVersion = appKey.GetValue("DisplayVersion").ToString();
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                appKey.Close();
            }
            key.Close();
            return DisplayVersion;
        }

        private string Read_Version()
        {
            Download_Version();

            string line = null;
            try
            {
                StreamReader reader = new StreamReader(Version_path());
                line = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return line;
        }

        private void Download_Version()
        {
            try
            {
                //Client_V.DownloadFile("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/QnNA6BjpfUxOzg", Version_path());
                Client_V.DownloadFile("https://drive.google.com/uc?export=download&confirm=no_antivirus&id=18CCbwZeaiMpdi0tv7ISkuwbmmNKXCoO4", Version_path());

            }
            catch (Exception exp1)
            {
                MessageBox.Show(exp1.Message + "\nПробуем другую ссылку для скачивания...", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    Client_V.DownloadFile("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/QnNA6BjpfUxOzg", Version_path());
                    //Client_V.DownloadFile("https://drive.google.com/uc?export=download&confirm=no_antivirus&id=18CCbwZeaiMpdi0tv7ISkuwbmmNKXCoO4", Version_path());

                }
                catch (Exception exp2)
                {
                    MessageBox.Show(exp2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Download_Update()
        {
            string url = "https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/jKUL3NJ2guFmNw";
            try
            {
                Client_Z.OpenRead(url);

                Client_Z.DownloadProgressChanged += (s, e) =>
                {
                    string size = (e.TotalBytesToReceive / 1048576).ToString("#.## МБ");
                    label2.Text = $"Размер файла: {size}\n Загружено: {e.ProgressPercentage} %({((double)e.BytesReceived / 1048576).ToString("#.## МБ")})";
                    progressBar1.Value = e.ProgressPercentage;
                };

                Client_Z.DownloadFileAsync(new Uri(url), UpdateZip_path());
            }
            catch (Exception exp1)
            {
                MessageBox.Show(exp1.Message + "\nПробуем другую ссылку для скачивания...", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    url = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1iMleCPeONbqedbgXcrXDaPDzgDIIuozF";

                    Client_Z.OpenRead(url);

                    Client_Z.DownloadProgressChanged += (s, e) =>
                    {
                        string size = (e.TotalBytesToReceive / 1048576).ToString("#.## МБ");
                        label2.Text = $"Размер файла: {size}\n Загружено: {e.ProgressPercentage} %({((double)e.BytesReceived / 1048576).ToString("#.## МБ")})";
                        progressBar1.Value = e.ProgressPercentage;
                    };

                    Client_Z.DownloadFileAsync(new Uri(url), UpdateZip_path());

                }
                catch (Exception exp2)
                {
                    MessageBox.Show(exp2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear_wc();
                }
                
            }
        }

        private void Zip_extr()
        {
            Task t = Task.Run(() => {
                try
                {
                    ZipFile.ExtractToDirectory(UpdateZip_path(), FromZip_toPath());
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear_wc();
                }
            });
            if (t.Wait(5000) == false)
            {
                MessageBox.Show("Время распаковки превышено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Распаковка завершена.\nПосле продолжения программа завершится и запустится обновление.\nПожалуйста, подождите...", "Подготовка обновления", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Start_Update()
        {

            if (File.Exists(Update_File()) && File.Exists(Update_bat()) && File.Exists(Uninstall_File()) && File.Exists(Uninstall_ini_File()))
            {
                try
                {
                    button3.Enabled = true;
                    button1.Enabled = true;

                    ProcessStartInfo info = new ProcessStartInfo(Update_bat());
                    info.Arguments = @"C:\Users\" + Environment.UserName + @"\Downloads";
                    Process.Start(info);

                    this.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_wc();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Файл обновления не найден или поврежден!\nПопробуйте повторить проверку обновлений.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear_wc();

            Del_all_downloads();

            Client_V = new WebClient();
            Client_Z = new WebClient();

            button3.Enabled = false;
            button1.Enabled = false;


            if (Check_Version() == true)
            {
                DialogResult = MessageBox.Show("Обнаружена более новая версия приложения. (new " + Read_Version() + ")\n\nЖелаете провести обновление установленного приложения?\nТекущая версия (" + GetReg_Version() + ")",
                        "Проверка обновлений",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Client_Z.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
                        
                        Download_Update();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    button3.Enabled = true;
                    button1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Текущая версия приложения актуальна.",
                "Проверка обновлений",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                button3.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Загрузка была отменена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
            }

            DialogResult = MessageBox.Show("Загрузка файла обновления завершена.\nПереходим к Распаковке.\nПожалуйста, подождите...", "Загрузка обновления", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Zip_extr();

            Start_Update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
