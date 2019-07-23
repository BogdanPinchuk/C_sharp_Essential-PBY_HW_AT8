using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // вивід інформації про наявні кольори через колекції
            Console.WriteLine("\n\tНаявні кольори в консолі:\n");

#if false
            // створення масиву/колекції кольорів
            List<ConsoleColor> colors = Enum
                .GetValues(typeof(ConsoleColor))
                .Cast<ConsoleColor>()
                .ToList();

            #region Використовуючи колекції
            foreach (var color in colors)
            {
                if (color == ConsoleColor.Black)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = color;
                Console.WriteLine($"\t\t{color} - {(int)color}");
                Console.ResetColor();
            }
            #endregion  
#endif

            #region Використовуючи масив
            // створення масиву/колекції кольорів
            var colors = Enum
                .GetValues(typeof(ConsoleColor))
                .Cast<ConsoleColor>()
                .ToArray();

            for (int i = 0; i < colors.Length; i++)
            {
                Console.BackgroundColor = colors[colors.Length - i - 1];
                Console.ForegroundColor = colors[i];
                Console.WriteLine($"\t\t{colors[i]} - {(int)colors[i]}");
                Console.ResetColor();
            }
            #endregion

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
