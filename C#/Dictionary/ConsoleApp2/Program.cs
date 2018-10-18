using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //  Создать класс АвторКниги: ПолАвтора, Фамилия, Имя,ГодРождения.Создать класс книга: Название, Тематика, ГодИздания.Программа должна работать
    //  с авторами и их книгами. (Dictaniory<Author, List<Book>> Library). В программе нужно будет реализовать пункты меню:
    //- Добавить автора
    //- Удалить автора
    //- Добавить книгу
    //- Удалить книгу
    //- Вывести полную информацию по библиотеке
    //- Вывести книги конкретного автора
    //- Вывести книги конкретной тематики
    class Program
    {
        // parts.Add(new Part() { PartName = "crank arm", PartId = 1234});
        static void Main(string[] args)
        {
            Author author = new Author();
            List<Book> books = new List<Book>();
            int Num = 0;
            Dictionary<Author, List<Book>> Library = new Dictionary<Author, List<Book>>();

                Book book =
                     new Book("Мертвые души", "Художественная", 1972);

                books.Add(new Book("Мертвые души", "Художественная", 1972));
                books.Add(new Book("Мертвые ", "Художественная", 1972));

                Library.Add(new Author(1,"Гоголь", "Николай", "м", 1809), books);
                Library.Add(new Author(2,"Гоголь", "Николай", "м", 1809), new List<Book>());
            bool y = true;
            while (y)
            {
                Console.Clear();
                
                Console.WriteLine("Выберете действие");
                Console.WriteLine("1. Добавить автора");
                Console.WriteLine("2. Удалить автора");
                Console.WriteLine("3. Добавить книгу");
                Console.WriteLine("4. Вывести полную информацию по библиотеке");
                int n = 0;
                n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            
                            try
                            {
                                Num++;
                                Library.Add(author.AddAuthor(), new List<Book>());   
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка!!!Неверный ввод!!!");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите номер автора");
                             int i = Int32.Parse(Console.ReadLine());
                            ICollection<Author> Autors = Library.Keys;
                            foreach (Author A in Autors)
                            {
                                try
                                {
                                    if (A.Num == i)
                                        Autors.Remove(new Author(i,"","","",i));
                                }
                                catch
                                {
                                    Console.WriteLine("!");
                                }
                            }

                            break;
                         
                        }
                    case 3:
                        {
                            try
                            {
                                Book b = new Book();
                                b.AddBook();
                                List<Book> b1 = new List<Book>();
                                b1.Add(b);
                                Library.Add(new Author(), b1);
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка!!!Неверный ввод!!!");
                            }
                            break;
                            }
                    case 4:
                        {
                            ICollection<Author> Autor = Library.Keys;
                            foreach (Author A in Autor)
                            {
                                Console.WriteLine(A);
                                ICollection<Book> Books = Library[A];
                                foreach (Book B in Books)
                                {
                                    Console.WriteLine(B);
                                }
                                Console.WriteLine();
                            }
                            break;
                            
                        }

                }
                Console.WriteLine("Продолжить работу с программой?");
                Console.WriteLine("(Нет - выйти, другое - продолжить)");
                if (Console.ReadLine() == "Нет")
                    y = false;
            }
        }
    }
    class Author
    {
        private int Number ;
        private string Surname;
        private string Name;
        private string sex;
        private int YearOfBirth;
        public int Num { get; set; }
        public string S { get; set; }
        public string N { get; set; }
        public string s { get; set; }
        public int Y { get; set; }
        public Author() { }
        public Author(int Num, String S, string N, string s, int Y)
        {
            this.Num =Num;
            this.S = S;
            this.N = N;
            this.s = s;
            this.Y = Y;
        }
        public Author AddAuthor()
        {
            Console.WriteLine("Введите ID автора");
            this.Num = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите Фамилию");
            this.S = Console.ReadLine();
            Console.WriteLine("Введите Имя");
            this.N = Console.ReadLine();
            Console.WriteLine("Введите пол (м/ж)");
            this.s = Console.ReadLine();
            Console.WriteLine("Введите год рождения");

            this.Y = Int32.Parse(Console.ReadLine());
            return new Author(this.Num,this.S, this.N, this.s, this.Y);
        }
        public override string ToString()
        {
            return String.Format("ID: {0}. {1} {2}, пол: {3}, год рождения: {4}",this.Num, this.S, this.N, this.s, this.Y);
        }

    }
    class Book
    {
        private string Name;
        private string Subjects;
        private int Year;
        public string N { get; set; }
        public string S { get; set; }
        public int Y { get; set; }
        public Book() { }
        public Book(string N, string S, int Y)
        {
            this.N = N;
            this.S = S;
            this.Y = Y;
        }
        public Book AddBook()
        {
            Console.WriteLine("Введите название книги");
            this.N = Console.ReadLine();
            Console.WriteLine("Введите жанр книги");
            this.S = Console.ReadLine();
            Console.WriteLine("Введите год издания");
            this.Y = Int32.Parse(Console.ReadLine());
            return new Book(this.S, this.N, this.Y);
        }
        public override string ToString()
        {
            return String.Format("{0}, Жанр: {1}, Год издания: {2}", this.N, this.S, this.Y);
        }
    }
}
