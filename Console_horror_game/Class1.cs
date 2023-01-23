using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_horror_game
{
    public class RPS
    {
        public static int RPS_Mech()
        {
            // камень - 1 бумага - 2 ножницы - 3
            string userChoice = Console.ReadLine();

            Random r = new Random();
            int computerChoice = r.Next(4);

            if (computerChoice == 1)
            {
                if (userChoice == "1")
                {
                    Console.WriteLine("Камень");
                    Console.WriteLine("Ничья");
                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("Бумага");
                    Console.WriteLine("Ничья");

                }
                else if (userChoice == "3")
                {
                    Console.WriteLine("Ножницы");
                    Console.WriteLine("Ничья");
                }
                else
                {
                    Console.WriteLine("Выбери 1, 2 ИЛИ 3");

                }
                return 0;

            }

            else if (computerChoice == 2)
            {
                if (userChoice == "1")
                {
                    Console.WriteLine("Бумага");
                    Console.WriteLine("ТЫ ПРОИГРАЛ");

                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("Ножницы");
                    Console.WriteLine("ТЫ ПРОИГРАЛ");

                }
                else if (userChoice == "3")
                {
                    Console.WriteLine("Камень");
                    Console.WriteLine("ТЫ ПРОИГРАЛ");
                }
                else
                {
                    Console.WriteLine("Выбери 1, 2 ИЛИ 3");
                }
                return 1;
            }
            else if (computerChoice == 3)
            {
                if (userChoice == "1")
                {
                    Console.WriteLine("Ножницы");
                    Console.WriteLine("я проиграл...");

                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("Камень");
                    Console.WriteLine("я проиграл...");

                }
                else if (userChoice == "3")
                {
                    Console.WriteLine("Бумага");
                    Console.WriteLine("я проиграл...");

                }
                else
                {
                    Console.WriteLine("Выбери 1, 2 ИЛИ 3");

                }
                return 2;

            }
            return 69;
        }
    }
}
