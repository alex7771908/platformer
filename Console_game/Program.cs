using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Console_game
{
    internal class Program
    {
        /*Console.SetCursorPosition(20, 20);
         Console.ReadLine();
         Console.SetCursorPosition(5, 10);
         Console.ReadLine();
         Console.SetCursorPosition(5, 10);
         Console.ReadLine(); //перезаписываем прошлые данные в 5, 10
         Console.SetCursorPosition(20, 20);
            for(int i = 100; i > 1; i--)
            {
                Console.CursorSize = i;
                Thread.Sleep(1);
            }   
         */
        static int x = Console.CursorLeft;
        static int y = Console.CursorTop;
        static string texture = "#";
        static string texture_bullet = "-";
        public static Timer _timer = null;
        static void Main(string[] args)
        {
            
            Console.WriteLine(texture);
            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Move(key);
                Shoot(key);
            }
            

            Console.ReadLine(); // pause
        }

        public static void Shoot(ConsoleKeyInfo key)
        {
            
            int x = Console.CursorLeft;
            if(key.Key == ConsoleKey.Enter)
            {
                while(x <= Console.WindowWidth)
                {
                    _timer = new Timer(TimerTick, null, 0, 100);
                }
            }
        }

        public static void TimerTick(object o)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(" ");

            x = Console.CursorLeft;
            y = Console.CursorTop;

            Console.Write(texture_bullet);
        }

        public static void Move(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.D)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");

                x = Console.CursorLeft;
                y = Console.CursorTop;

                Console.Write(texture);

            }


            if (key.Key == ConsoleKey.A)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
                Console.SetCursorPosition(x - 1, y);

                x = Console.CursorLeft;
                y = Console.CursorTop;

                Console.Write(texture);

            }

            if (key.Key == ConsoleKey.S)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
                Console.SetCursorPosition(x, y + 1);


                x = Console.CursorLeft;
                y = Console.CursorTop;



                Console.Write(texture);

            }
            if (key.Key == ConsoleKey.W)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
                Console.SetCursorPosition(x, y - 1);


                x = Console.CursorLeft;
                y = Console.CursorTop;



                Console.Write(texture);

            }
        }
    }
}
