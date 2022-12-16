using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicum10_Task1_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //путь к папку Temp
            string rootPath = "C:\\temp";
            if (Directory.Exists(rootPath))
            {
                MessageBox.Show("Папка уже создана!");

                FileInfo _t1 = new FileInfo($"{rootPath}\\All\\t1.txt");
                FileInfo _t2 = new FileInfo($"{rootPath}\\All\\t2.txt");
                FileInfo _t3 = new FileInfo($"{rootPath}\\All\\t3.txt");

                //выводим информацию о файлах
                richTextBox1.Text = "__________________t1__________________\n";
                richTextBox1.Text += $"Имя файла: {_t1.Name}\n";
                richTextBox1.Text += $"Расширение файла: {_t1.Extension}\n";
                richTextBox1.Text += $"Расположение файла: {_t1.FullName} \n";
                richTextBox1.Text += $"Время создания файла: {_t1.CreationTime} \n";
                richTextBox1.Text += $"Атрибуты файла: {_t1.Attributes}";

                richTextBox2.Text = "__________________t2__________________\n";
                richTextBox2.Text += $"Имя файла: {_t2.Name}\n";
                richTextBox2.Text += $"Расширение файла: {_t2.Extension} \n";
                richTextBox2.Text += $"Расположение файла: {_t2.FullName} \n";
                richTextBox2.Text += $"Время создания файла: {_t2.CreationTime}  \n";
                richTextBox2.Text += $"Атрибуты файла: {_t2.Attributes}";

                richTextBox3.Text = "__________________t3__________________\n";
                richTextBox3.Text += $"Имя файла: {_t3.Name}  \n";
                richTextBox3.Text += $"Расширение файла: {_t3.Extension}  \n";
                richTextBox3.Text += $"Расположение файла: {_t3.FullName}  \n";
                richTextBox3.Text += $"Время создания файла: {_t3.CreationTime}  \n";
                richTextBox3.Text += $"Атрибуты файла: {_t3.Attributes}";

                DirectoryInfo _all = new DirectoryInfo($"{rootPath}\\All");
                richTextBox4.Text = "__________________All__________________\n";
                richTextBox4.Text += $"Путь до папки: {_all.FullName}  \n";
                richTextBox4.Text += $"Дата создания: {_all.CreationTime}  \n";
                richTextBox4.Text += $"Атрибуты: {_all.Attributes}\n";
                richTextBox4.Text += $"Корень: {_all.Root}";
                return;
            }

            //создание папок К1 и К2
            Directory.CreateDirectory($"{rootPath}\\K1");
            Directory.CreateDirectory($"{rootPath}\\K2");

            //создание файлов и запись в них текста
            StreamWriter t1 = new StreamWriter($"{rootPath}\\K1\\t1.txt");
            t1.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            t1.Close();
            StreamWriter t2 = new StreamWriter($"{rootPath}\\K1\\t2.txt");
            t2.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            t2.Close();

            //создаем переменную для хранения и переносим в нее текст из файлов
            string str;
            StreamReader t1Read = new StreamReader($"{rootPath}\\K1\\t1.txt");
            str = t1Read.ReadToEnd();
            t1Read.Close();
            StreamReader t2Read = new StreamReader($"{rootPath}\\K1\\t2.txt");
            str += t2Read.ReadToEnd();
            t2Read.Close();

            //создаем файл т3 и записываем в него текст из файлов т1 и т2
            StreamWriter t3 = new StreamWriter($"{rootPath}\\K2\\t3.txt");
            t3.WriteLine(str);
            t3.Close();

            //информирование пользователя о создании папок
            MessageBox.Show("Папки и файлы были созданы!");

            //получаем информацию о файлах
            FileInfo info_t1 = new FileInfo($"{rootPath}\\K1\\t1.txt");
            FileInfo info_t2 = new FileInfo($"{rootPath}\\K1\\t2.txt");
            FileInfo info_t3 = new FileInfo($"{rootPath}\\K2\\t3.txt");

            //выводим информацию о файлах
            richTextBox1.Text = "__________________t1__________________\n";
            richTextBox1.Text += $"Имя файла: {info_t1.Name}\n";
            richTextBox1.Text += $"Расширение файла: {info_t1.Extension}\n";
            richTextBox1.Text += $"Расположение файла: {info_t1.FullName} \n";
            richTextBox1.Text += $"Время создания файла: {info_t1.CreationTime} \n";
            richTextBox1.Text += $"Атрибуты файла: {info_t1.Attributes}";

            richTextBox2.Text = "__________________t2__________________\n";
            richTextBox2.Text += $"Имя файла: {info_t2.Name}\n";
            richTextBox2.Text += $"Расширение файла: {info_t2.Extension} \n";
            richTextBox2.Text += $"Расположение файла: {info_t2.FullName} \n";
            richTextBox2.Text += $"Время создания файла: {info_t2.CreationTime}  \n";
            richTextBox2.Text += $"Атрибуты файла: {info_t2.Attributes}";

            richTextBox3.Text = "__________________t3__________________\n";
            richTextBox3.Text += $"Имя файла: {info_t3.Name}  \n";
            richTextBox3.Text += $"Расширение файла: {info_t3.Extension}  \n";
            richTextBox3.Text += $"Расположение файла: {info_t3.FullName}  \n";
            richTextBox3.Text += $"Время создания файла: {info_t3.CreationTime}  \n";
            richTextBox3.Text += $"Атрибуты файла: {info_t3.Attributes}";

            //копирование файла т1 в папку к2
            File.Copy($"{rootPath}\\K1\\t1.txt", $"{rootPath}\\K2\\t1.txt");

            //перенос файла т2 в папку к2
            File.Move($"{rootPath}\\K1\\t2.txt", $"{rootPath}\\K2\\t2.txt");

            //удаление папки к1
            File.Delete($"{rootPath}\\K1\\t1.txt");
            Directory.Delete($"{rootPath}\\K1");

            //изменение имени папки k2 на All
            Directory.Move($"{rootPath}\\K2", $"{rootPath}\\All");

            //получение информации о папке All и ее вывод
            DirectoryInfo info_all = new DirectoryInfo($"{rootPath}\\All");
            richTextBox4.Text = "__________________All__________________\n";
            richTextBox4.Text += $"Путь до папки: {info_all.FullName}  \n";
            richTextBox4.Text += $"Дата создания: {info_all.CreationTime}  \n";
            richTextBox4.Text += $"Атрибуты: {info_all.Attributes}\n";
            richTextBox4.Text += $"Корень: {info_all.Root}";
        }
    }
}
