using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення масиву об'єктів
            MyArrayList list = new MyArrayList();

            #region куча всього
            // + bool
            list.AddRange(true, false);

            // + byte
            list.AddRange(byte.MinValue, byte.MaxValue);

            // + char
            list.AddRange('B', 'o', 'g', 'd', 'a', 'n');

            // + decimal
            list.AddRange(decimal.MinValue, decimal.MaxValue, 
                decimal.MinusOne, decimal.One, decimal.Zero);

            // + double
            list.AddRange(Math.PI, Math.E, double.Epsilon, double.NaN, 
                double.PositiveInfinity, double.NegativeInfinity, 
                double.MaxValue, double.MinValue);

            // + float
            list.AddRange(float.MinValue, float.MaxValue, float.Epsilon);

            // + int
            list.AddRange(int.MinValue, int.MaxValue);

            // + long
            list.AddRange(long.MinValue, long.MaxValue);

            // + string
            list.Add("Pinchuk");
            #endregion

            // вивід результату в консоль
            Console.WriteLine("\n\tВсе що було вміщенно в даний масив:");

            for (int i = 0; i < list.Count; i++)
            {
                // сильно довге
                //Console.WriteLine("Тип: " + list[i].GetType().Name + " - значення: " + list[i]);
                Console.WriteLine(list[i].GetType().Name + " : " + list[i]);
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
