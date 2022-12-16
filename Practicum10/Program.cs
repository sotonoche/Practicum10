using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Dynamic;

namespace Practicum10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь к папку Temp
            string rootPath = "C:\\temp";
            if (Directory.Exists(rootPath))
            {
                Console.WriteLine("Папка уже создана!");

                FileInfo _t1 = new FileInfo($"{rootPath}\\All\\t1.txt");
                FileInfo _t2 = new FileInfo($"{rootPath}\\All\\t2.txt");
                FileInfo _t3 = new FileInfo($"{rootPath}\\All\\t3.txt");

                //выводим информацию о файлах
                Console.WriteLine("__________________t1__________________");
                Console.WriteLine($"Имя файла: {_t1.Name}");
                Console.WriteLine($"Расширение файла: {_t1.Extension}");
                Console.WriteLine($"Расположение файла: {_t1.FullName}");
                Console.WriteLine($"Время создания файла: {_t1.CreationTime}");
                Console.WriteLine($"Атрибуты файла: {_t1.Attributes}");

                Console.WriteLine("\n__________________t2__________________");
                Console.WriteLine($"Имя файла: {_t2.Name}");
                Console.WriteLine($"Расширение файла: {_t2.Extension}");
                Console.WriteLine($"Расположение файла: {_t2.FullName}");
                Console.WriteLine($"Время создания файла: {_t2.CreationTime}");
                Console.WriteLine($"Атрибуты файла: {_t2.Attributes}");

                Console.WriteLine("\n__________________t3__________________");
                Console.WriteLine($"Имя файла: {_t3.Name}");
                Console.WriteLine($"Расширение файла: {_t3.Extension}");
                Console.WriteLine($"Расположение файла: {_t3.FullName}");
                Console.WriteLine($"Время создания файла: {_t3.CreationTime}");
                Console.WriteLine($"Атрибуты файла: {_t3.Attributes}");

                DirectoryInfo _all = new DirectoryInfo($"{rootPath}\\All");
                Console.WriteLine("\n\n__________________All__________________");
                Console.WriteLine($"Путь до папки: {_all.FullName}");
                Console.WriteLine($"Дата создания: {_all.CreationTime}");
                Console.WriteLine($"Атрибуты: {_all.Attributes}");
                Console.WriteLine($"Корень: {_all.Root}");
                return;
            }

            //создание папок К1 и К2
            Directory.CreateDirectory($"{rootPath}\\K1");
            Directory.CreateDirectory($"{rootPath}\\K2");

            //создание файлов и запись в них текста
            StreamWriter t1 = new StreamWriter($"{rootPath}\\K1\\t1.txt");
            t1.WriteLine("Кирсанов Кирилл Алексеевич, 2004 года рождения, место жительства г. Владимир");
            t1.Close();
            StreamWriter t2 = new StreamWriter($"{rootPath}\\K1\\t2.txt");
            t2.WriteLine("Кирсанов Алексей Алексеевич, 1973 года рождения, место жительства г.Владимир");
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

            //получаем информацию о файлах
            FileInfo info_t1 = new FileInfo($"{rootPath}\\K1\\t1.txt");
            FileInfo info_t2 = new FileInfo($"{rootPath}\\K1\\t2.txt");
            FileInfo info_t3 = new FileInfo($"{rootPath}\\K2\\t3.txt");

            //выводим информацию о файлах
            Console.WriteLine("__________________t1__________________");
            Console.WriteLine($"Имя файла: {info_t1.Name}");
            Console.WriteLine($"Расширение файла: {info_t1.Extension}");
            Console.WriteLine($"Расположение файла: {info_t1.FullName}");
            Console.WriteLine($"Время создания файла: {info_t1.CreationTime}");
            Console.WriteLine($"Атрибуты файла: {info_t1.Attributes}");

            Console.WriteLine("\n__________________t2__________________");
            Console.WriteLine($"Имя файла: {info_t2.Name}");
            Console.WriteLine($"Расширение файла: {info_t2.Extension}");
            Console.WriteLine($"Расположение файла: {info_t2.FullName}");
            Console.WriteLine($"Время создания файла: {info_t2.CreationTime}");
            Console.WriteLine($"Атрибуты файла: {info_t2.Attributes}");

            Console.WriteLine("\n__________________t3__________________");
            Console.WriteLine($"Имя файла: {info_t3.Name}");
            Console.WriteLine($"Расширение файла: {info_t3.Extension}");
            Console.WriteLine($"Расположение файла: {info_t3.FullName}");
            Console.WriteLine($"Время создания файла: {info_t3.CreationTime}");
            Console.WriteLine($"Атрибуты файла: {info_t3.Attributes}");

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
            Console.WriteLine("\n\n__________________All__________________");
            Console.WriteLine($"Путь до папки: {info_all.FullName}");
            Console.WriteLine($"Дата создания: {info_all.CreationTime}");
            Console.WriteLine($"Атрибуты: {info_all.Attributes}");
            Console.WriteLine($"Корень: {info_all.Root}");
        }
    }
}
