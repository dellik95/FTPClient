using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Form1 : MetroForm
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Ftp ftp = null;
        List<string> link = new List<string>();

        public Form1()
        {
            InitializeComponent();
            string[] content = File.ReadAllLines(Path.GetFullPath("ftplist.txt"));
            listBox2.DataSource = content;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           // Enter ent = new Enter();
           // ent.ShowDialog();

        }


        async private void cnct_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (host_tb.Text != "")
                {
                    ftp = new Ftp(host_tb.Text, login_tb.Text, pass_tb.Text);

                }
                else
                {
                    ftp = new Ftp(listBox2.SelectedItem.ToString(), login_tb.Text, pass_tb.Text);

                }
                string[] str = await Task.Factory.StartNew<string[]>(() => ftp.DirectoryListSimple(""), TaskCreationOptions.LongRunning);
                listBox1.DataSource = str;

                if (host_tb.Text != "")
                {
                    link.Add(host_tb.Text);
                }
                else
                {
                    link.Add(listBox2.SelectedItem.ToString());
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите сервер из списка или введите вручную");
            }
            catch (WebException)
            {
                MessageBox.Show("Сервер не доступен");
            }
            catch (Exception)
            {
                MessageBox.Show("Сервер не доступен");
            }
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All|*.*";
            openFileDialog1.Title = "Файл для загрузки";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ftp.Upload(Path.GetFileName(openFileDialog1.FileName), openFileDialog1.FileName);
            }
        }

        private void download_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splite = listBox1.SelectedItem.ToString().Split('.');
                saveFileDialog1.Filter = string.Format(splite[splite.Length - 1] + "|*.{0}", splite[splite.Length - 1]);
                saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(listBox1.SelectedItem.ToString());
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ftp.Download(listBox1.SelectedItem.ToString(), saveFileDialog1.FileName);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбырете файл");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Выбырете файл");
            }
            catch (Exception)
            {
                MessageBox.Show("Выбырете файл");
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ftp.Delete(listBox1.SelectedItem.ToString());
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбырете файл");
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Выбырете файл");
            }
            catch (Exception)
            {
                MessageBox.Show("Выбырете файл");
            }
        }

        private void ftplist_btn_Click(object sender, EventArgs e)
        {

            try
            {
                openFileDialog1.Filter = "Текстовый документ|*.txt|все|*.*";
                openFileDialog1.Title = "Список серверов";
                string[] content;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog1.FileName = Path.GetFileName(openFileDialog1.FileName);
                    content = File.ReadAllLines(openFileDialog1.FileName);
                    listBox2.DataSource = content;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найден");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения файла");
            }

        }




        async private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Split('.').Length == 1)
            {

                download_btn.Enabled = false;

                if (listBox1.SelectedItem.ToString() == "В предыдущую папку")
                {


                    if ((link.ToArray().Length - 1) != 0)
                    {
                        link.RemoveAt(link.ToArray().Length - 1);
                        host_tb.Text = link[link.ToArray().Length - 1];
                        ftp = new Ftp(link[link.ToArray().Length - 1], login_tb.Text, pass_tb.Text);
                        string[] str = await Task.Factory.StartNew<string[]>(() => ftp.DirectoryListSimple(""), TaskCreationOptions.LongRunning);
                        listBox1.DataSource = str;
                    }
                    else
                    {
                        ftp = new Ftp(link[0], login_tb.Text, pass_tb.Text);
                        string[] str = await Task.Factory.StartNew<string[]>(() => ftp.DirectoryListSimple(""), TaskCreationOptions.LongRunning);
                        listBox1.DataSource = str;
                    }

                }
                else if (host_tb.Text != "")
                {
                    host_tb.Text += "/" + listBox1.SelectedItem.ToString();
                    ftp = new Ftp(host_tb.Text.ToString(), login_tb.Text, pass_tb.Text);

                    string[] str = await Task.Factory.StartNew<string[]>(() => ftp.DirectoryListSimple(""), TaskCreationOptions.LongRunning);
                    listBox1.DataSource = str;

                    link.Add(host_tb.Text);
                }

                else
                {

                    host_tb.Text += listBox2.SelectedItem.ToString() + "/" + listBox1.SelectedItem.ToString() + "/";
                    ftp = new Ftp(host_tb.Text.ToString(), login_tb.Text, pass_tb.Text);

                    string[] str = await Task.Factory.StartNew<string[]>(() => ftp.DirectoryListSimple(""), TaskCreationOptions.LongRunning);
                    listBox1.DataSource = str;
                    link.Add(host_tb.Text);

                }

            }
            else
            {
                download_btn.Enabled = true;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Split('.').Length == 1)
            {
                download_btn.Enabled = false;
            }
            else
            {
                download_btn.Enabled = true;
            }
        }
    }
}
