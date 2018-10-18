using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//пользователь вводит имя каталога – необходимо вывести все подкаталоги и файлы
//по указанному пути
//Пользователь вводит путь к каталогу и слово, необходимо найти все файлы и каталоги
//в котором включается это слово
namespace ConsoleApp4
{

    class Program
    {
        static public void Find(String[] dir)
        {

            foreach (string d in dir)
            {
                try
                {
                    Console.WriteLine(Path.GetFileName(d)); // одни папки
                    String[] dirs2 = Directory.GetDirectories(d);


                    foreach (string c in dirs2)
                    {
                        Console.WriteLine(Path.GetFileName(c));
                        Find(dirs2);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            //string dirName = "C:\\";
            String[] dirs = Directory.GetDirectories(@"C:\");

            Find(dirs);



            //foreach (string d in dirs)
            //{
            //    Console.WriteLine(Path.GetFileName(d)); // одни папки

            //while (!Directory.Exists(dirName))
            //{
            //    foreach (string c in dirs)
            //        Console.WriteLine(Path.GetFileName(c));
            //}

            //}


            //Console.WriteLine("введите путь");
            //string g = Console.ReadLine();
            //Console.WriteLine("введите слово для поиска");
            //string f = Console.ReadLine();
            //String[] dirs = Directory.GetDirectories(@g, f);
            //Console.WriteLine("Папки:");
            //foreach (string d in dirs)
            //{
            //    Console.WriteLine(Path.GetFileName(d)); // одни папки
            //}
            //string[] files = Directory.GetFiles(@g, f); //	Возвращает список файлов
            //Console.WriteLine("Файлы:");
            //foreach (string c in files)
            //{
            //    Console.WriteLine(c);
            //}

        }
    }
}
