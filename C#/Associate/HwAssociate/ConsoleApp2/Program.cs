using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //Создать класс сотрудник.ПОля: фамилия, имя, возраст, должность.Программа работает со списком(коллекцией) сотрудников.Функциональность:
    //- Добавить сотрудника
    //- Удалить сотрудника по индексу
    //- Вывести всех сотрудников
    //- Вывести сотрудников, у которых в фамилии есть введенные символы
    //- Отсортировать коллекцию по возрасту сотрудников(IComparable)
    //- Отсортировать по фамилии
    class Program
    {

        static void Main(string[] args)
        {
            Associate a = new Associate();
            List<Associate> Ass = new List<Associate>();

            bool y = true;
            while (y)
            {
                Console.Clear();
                Console.WriteLine("Выберете операцию:");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Удалить сотрудника по индексу");
                Console.WriteLine("3. Вывести всех сотрудников");
                Console.WriteLine("4. Вывести сотрудников, у которых в фамилии есть введенные символы");
                Console.WriteLine("5. Отсортировать коллекцию по возрасту сотрудников");
                Console.WriteLine("6. Отсортировать по фамилии");
                int n = 0;
                n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            Ass.Add(a.AddAssociate());
                            break;
                        }
                    case 2:
                        {
                            if (a.check(Ass) == 0)
                                break;
                            Console.WriteLine("Введите индекс сотрудника");
                            Ass.RemoveAt(Int32.Parse(Console.ReadLine()));

                            break;
                        }
                    case 3:
                        {
                            if (a.check(Ass) == 0)
                                break;
                            foreach (Associate s in Ass)
                            {
                                Console.WriteLine(s.Show());
                            }
                            break;
                        }
                    case 4:
                        {
                            if (a.check(Ass) == 0)
                                break;
                            a.Find(Ass);
                            //Console.WriteLine("Введите символы для поиска");
                            //string z = Console.ReadLine();
                            //for (int i = 0; i < Ass.Count; i++)
                            //{
                            //    if (Ass[i].S.IndexOf(z) != -1)
                            //        Console.WriteLine(Ass[i].Show());
                            //}
                            break;
                        }
                    case 5:
                        {
                            if (a.check(Ass) == 0)
                                break;
                            Ass.Sort();
                            foreach (Associate s in Ass)
                            {
                                Console.WriteLine(s.Show());
                            }
                            break;
                        }
                    case 6:
                        {
                            if (a.check(Ass) == 0)
                                break;
                            a.SortByName(Ass);
                            //bool flag = true;
                            //while (flag)
                            //{
                            //    flag = false;
                            //    for (int i = 0; i < Ass.Count - 1; ++i)
                            //        if (Ass[i].S.CompareTo(Ass[i + 1].S) > 0)
                            //        {
                            //            string buf = Ass[i].S;
                            //            Ass[i].S = Ass[i + 1].S;
                            //            Ass[i + 1].S = buf;
                            //            flag = true;
                            //        }
                            //}
                            foreach (Associate s in Ass)
                            {
                                Console.WriteLine(s.Show());
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод!!! попробуйте еще");
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
}
public delegate int SortByName(string s);

class Associate : IComparable<Associate>
{
    private string Surname;
    private string Name;
    int age;
    private string Position;
    public Associate() { }
    public Associate(string S, string N, int A, string P)
    {
        this.A = A;
        this.N = N;
        this.P = P;
        this.S = S;
    }

    public String Show()
    {
        return string.Format("{0} {1}, возраст: {2}, должность: {3}", this.S, this.N, this.A, this.P);
    }
    public Associate AddAssociate()
    {
        Console.WriteLine("Введите Фамилию сотрудника");
        this.S = Console.ReadLine();
        Console.WriteLine("Введите Имя сотрудника");
        this.N = Console.ReadLine();
        Console.WriteLine("Введите возраст сотрудника");
        this.A = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Введите Должность сотрудника");
        this.P = Console.ReadLine();
        return new Associate(this.S, this.N, this.A, this.P);
    }

    public string S { get; set; }
    public string N { get; set; }
    public int A
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
                value *= -1;
            this.age = value;
        }

    }
    public string P { get; set; }

    public int CompareTo(Associate obj)
    {
        return A.CompareTo(obj.A);
    }
    public void Find(List<Associate> Ass)
    {
        Console.WriteLine("Введите символы для поиска");
        string z = Console.ReadLine();
        for (int i = 0; i < Ass.Count; i++)
        {
            if (Ass[i].S.IndexOf(z) != -1)
                Console.WriteLine(Ass[i].Show());
        }
    }
    public void SortByName(List<Associate> Ass)
    {

        bool flag = true;
        while (flag)
        {
            flag = false;
            for (int i = 0; i < Ass.Count - 1; ++i)
                if (Ass[i].S.CompareTo(Ass[i + 1].S) > 0)
                {
                    string buf = Ass[i].S;
                    Ass[i].S = Ass[i + 1].S;
                    Ass[i + 1].S = buf;
                    flag = true;
                }
        }
    }
    public int check (List<Associate> Ass)
    {
        if(Ass.Count==0)
        Console.WriteLine("В списке нет сотрудников!");
        return Ass.Count;
    }


}

