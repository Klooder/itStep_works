using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
// ходить - стрелки
// стрелять - пробел
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)

        {

            ConsoleKeyInfo CKI = new ConsoleKeyInfo();
            int n = 0;

            do
            {
                Game G = new Game();
                if (CKI.Key == ConsoleKey.Escape)
                {
                    break; // прерываем текущую игру
                }

                switch (CKI.Key)   // обрабатываем нажатия клавиш стрелок
                {
                    case ConsoleKey.DownArrow:
                        n++;
                        if (n > 1)
                            n = 0;


                        break;
                    case ConsoleKey.UpArrow:
                        n--;
                        if (n < 0)
                            n = 1;


                        break;
                }

                Console.Clear();

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (CKI.Key == ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        G.run();
                        Console.Clear();
                        //  break;
                    }
                }
                Console.CursorLeft = 50;
                Console.CursorTop = 10;
                Console.WriteLine("Новая игра");
                Console.ForegroundColor = ConsoleColor.White;
                if (n == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (CKI.Key == ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                }
                Console.CursorLeft = 52;
                Console.CursorTop = 11;
                Console.WriteLine("Выход");
                Console.ForegroundColor = ConsoleColor.White;

            } while ((CKI = Console.ReadKey(true)).Key != ConsoleKey.Escape);


        }
    }
    class Game
    {
        string strMap =
"0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
"0000100000011111111111110000000111111000000000000000000000001111111111000000000000000000001111000000" +
"0000100000010000000000010000001100001111110000000000000000001000000001111111111110000000001000000000" +
"0000100000010000001000010000001000000000010000001000000000001000000001000000000010000000001000000000" +
"0000111111111111111111111111111111110111111111111111111111111111111111111111111111111111111111100000" +
"0000100000100010000100000000001000001000000000000000000000000000000000000000000000001000000000000000" +
"0000111100111110011100111111111111111111111111111111110000000000000000111111000000001111111111100000" +
"0000000000000000010000100000000000000000010000000000010000000000000000100001000001000000000000000000" +
"0000011111111111111011111111111111111111111110111111111111111111111111110111111111111111111111100000" +
"0000000000000000000000000000000000000000000000000000010000000000000000000001000000000000000001000000" +
"0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000" +
"0000011111111111111111111111111111111111111111111111111111111111111111111111111111111111111111100000" +
"0000000000000000010000000000000010000001000000000000010000000001000000000000000000000000000000000000" +
"0000000000000111111111000000000010000000100001111111111111111111000000000000000000011111111111100000" +
"0000000000000000000000000000000000000000000001000000000000000000000000000000000000100000000000000000" +
"0000011111111111111111111111111111111111111111111111111111111111111111111111111111111111111111100000" +
"0000000000000000000100000000000000000000000000000000000000000000000000000000100000000000000000000000" +
"0000000000000000000010000000000000010000000000010000001000000100000000000001110000000000000000000000" +
"0000011111111111111111111111111111111111111111111111111111111111111111111111111111111111111111000000" +
"0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000";
        static readonly int mapWidth = 100;
        static readonly int mapHeight = 20;
        static readonly int sizeBlock = 11;
        byte[,] map = new byte[mapHeight * sizeBlock, mapWidth * sizeBlock];
        int x = 0;
        int y = 0;
        Man Man = new Man(12, 49);
        Zombi zombi = new Zombi(16,16);

        public Game()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    char a = strMap[i * mapWidth + j];
                    byte v = (byte)((a == '0') ? 0 : 1);
                    for (int r = 0; r < sizeBlock; r++)
                    {
                        for (int c = 0; c < sizeBlock; c++)
                        {
                            map[i * sizeBlock + r, j * sizeBlock + c] = v;
                        }
                    }
                }
            }
        }

        public void show()
        {
            string tmp = "";
            Console.CursorTop = 0;
            Console.CursorLeft = 0;

            for (int i = 0; i < 28; i++)
            {

                for (int j = 0; j < 119; j++)
                {
                    string q = (map[y + i, x + j] == 0) ? "▒" : " "; //ALT 177
                 

                    tmp += q;
                }
                tmp += "\n";

            }
            Console.WriteLine(tmp);
        }

        public void run()
        {
            bool isRun = true;
            int X = Man.Z;  
            int Y = Man.C+20;
            int L = Man.C - 20;
            string m=Man.IManTop;
            int zz=1;
            int yy = 1;
            int kill = 0;
            int ll = 1;
            while (isRun)
            {

                Thread.Sleep(100);
              
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo CKI = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    switch (CKI.Key)
                    {

                        case ConsoleKey.Escape:
                            isRun = false;
                            break;
                        case ConsoleKey.RightArrow:
                            if (map[Man.Z + y, Man.C + x] == 0)
                                Man.C -= 4;
                           
                            if (x + 80 < mapWidth * sizeBlock)
                            {
                                x += 2;

                            }
                            if (Man.C < 78)
                            {
                                
                                m = Man.ManR;
                            }
                            Y--;
                            yy++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (map[Man.Z + y, Man.C + x] == 0)
                                Man.C += 4;
                            if (x > 0)
                            {
                                x -= 2;
                                m = Man.ManL;
                                Y--;
                               
                               
                            }
                            ll++;
                            L ++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (map[Man.Z + y, Man.C + x] == 0)
                                Man.Z += 4;
                            if (Man.Z > 0)
                            {
                                if (y > 0)
                                    y -= 2;

                                m = Man.IManTop;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (map[Man.Z + y, Man.C + x] == 0)
                                Man.Z -= 6;
                            if (y + 24 < mapHeight * sizeBlock)
                            {
                                m = Man.IMan;
                                y += 2;

                            }
                            zz++;
                            break;
                        case ConsoleKey.Spacebar:
                                int xs = Man.Z;
                                int ys = Man.C;
                            int xz = x;
                            int yz = y;
                           kill++;
                            for (int i = 0; i < 10; i++)
                            {
                                if (m == Man.ManR)
                                {
                                    if (xz + 80 < mapWidth * sizeBlock)
                                    {
                                        Console.CursorTop = xs + 1;
                                        Console.CursorLeft = ys++;
                                        xz += 2;
                                         yy = 0;
                                        zz = 0;

                                    }

                                }
                                
                                if (m == Man.ManL)
                                {
                                    if (xz > 0)
                                    {
                                        Console.CursorTop = xs + 1;
                                        Console.CursorLeft = ys--;
                                        xz-=2;
                                        ll = 0;
                                    }
                                 
                                }
                             
                                Console.Write(" ");
                                Thread.Sleep(10);
                                this.show();
                                Man.show(m);
                                Y = Man.C+30;
                                L = Man.C - 20;
                                 map[X, Y] = map[0, 0];
                            }
                            break;
                    }
                }
               
                this.show();
                Man.show(m);
                if (zz >= 18)
                {
                Zombi zombi = new Zombi(X, Y);
                zombi.show();
                    
                }
                if(ll >= 10)
                {
                    Zombi zombi = new Zombi(X, L);
                    zombi.show();
                }
                if(yy>=10)
                {
                    Zombi zombi = new Zombi(X, Y );
                    zombi.show();
                }
                if (map[Man.Z, Man.C] == map[X, Y])
                {
                    Console.Clear();
                    Console.CursorLeft = 52;
                    Console.CursorTop = 10;
                    Console.WriteLine(" Your Dead! ");
                    Console.CursorLeft = 50;
                    Console.CursorTop = 12;
                    Console.WriteLine("You Kill {0} zombi", kill);
                    Console.ReadKey();
                    break;
                }
                
            }


        }

    }
    class Man
    {

        public string ManR = "@" +
                     "(" + "|" + "\\" +
                      " |" + "\\";
        public string ManL = "@" +
             "/" + "|" + ")" +
             "/" + "| ";
        public string IMan = "@" +
                     "/" + "#" + "\\" +
                     "/" + " \\";
        public string IManTop = "@" +
                    "/" + "#" + "\\" +
                    "/" + " \\";

        private int z;
        private int c;
        public Man(int z, int c)
        {
            this.Z = z;
            this.C = c;
        }
        public int Z
        {
            get; set;
        }
        public int C { set; get; }

        public void show(string M)
        {
            Console.CursorTop = this.Z;
            Console.CursorLeft = this.C;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0 && j == 1)
                        Console.Write(M[0]);
                    if (i == 1 && j == 0)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C - 1;
                        Console.Write(M[1]);
                    }
                    if (i == 1 && j == 1)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C;
                        Console.Write(M[2]);
                    }
                    if (i == 1 && j == 2)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C + 1;
                        Console.Write(M[3]);
                    }
                    if (i == 2 && j == 0)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C + 1;
                        Console.Write(M[6]);
                    }
                    if (i == 2 && j == 1)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C;
                        Console.Write(M[5]);
                    }
                    if (i == 2 && j == 2)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C - 1;
                        Console.Write(M[4]);
                    }
                }
                Console.WriteLine();
            }

        }

    }
    class Zombi
    {
        public string zombi = "%" +
                     "\\" + "$" + "/" +
                     "/" + " \\";

        private int z;
        private int c;
        public Zombi(int z, int c)
        {
            this.Z = z;
            this.C = c;
        }
        public int Z
        {
            get; set;
        }
        public int C { set; get; }
        public void show()
        {
            Console.CursorTop = this.Z;
            Console.CursorLeft = this.C;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0 && j == 1)
                        Console.Write(zombi[0]);
                    if (i == 1 && j == 0)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C - 1;
                        Console.Write(zombi[1]);
                    }
                    if (i == 1 && j == 1)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C;
                        Console.Write(zombi[2]);
                    }
                    if (i == 1 && j == 2)
                    {
                        Console.CursorTop = this.Z + 1;
                        Console.CursorLeft = this.C + 1;
                        Console.Write(zombi[3]);
                    }
                    if (i == 2 && j == 0)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C + 1;
                        Console.Write(zombi[6]);
                    }
                    if (i == 2 && j == 1)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C;
                        Console.Write(zombi[5]);
                    }
                    if (i == 2 && j == 2)
                    {
                        Console.CursorTop = this.Z + 2;
                        Console.CursorLeft = this.C - 1;
                        Console.Write(zombi[4]);
                    }
                }
                Console.WriteLine();
            }

        }


    }
}
