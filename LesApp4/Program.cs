using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    class Program
    {
        /// <summary>
        /// Фрукти
        /// </summary>
        enum Fruits
        {
            /// <summary>
            /// Яблуко
            /// </summary>
            Apple,
            /// <summary>
            /// Груша
            /// </summary>
            Pear,
            /// <summary>
            /// Слива
            /// </summary>
            Plum,
            /// <summary>
            /// Абрикос
            /// </summary>
            Apricot,
            /// <summary>
            /// Персик
            /// </summary>
            Peach
        }
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // конвертуємо перерахунки в масив
            string[] fruits = Enum
                .GetValues(typeof(Fruits))
                .Cast<Fruits>()
                .Select(t => t.ToString())
                .ToArray();

            // цикл Дейкстри
            for (; ; )
            {
                // Чистка консолі
                Console.Clear();

                Console.WriteLine("Список фруктів:\n");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < fruits.Length; i++)
                {
                    Console.WriteLine("\t" + fruits[i]);
                }
                Console.ResetColor();

                // користувач вводить дані
                Console.Write("\nВведіть назву фрукта який Ви тільки що з'їли із списку: ");
                string s = Console.ReadLine();

                // зчиутвання дати (1-ше для тестування)
                DateTime date = new DateTime(2019, 07, 20, 16, 16, 16);
                date = DateTime.Now;

                // перевірка введених даних
                if (!Find(s, fruits))
                {
                    Console.WriteLine("\n\tСпробувати ще раз ввести назву фрукта? [т, н]");

                    var button = Console.ReadKey(true);

                    if ((button.KeyChar.ToString().ToLower() == "т") ||
                        (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
                    {
                        // спроба знову ввести назву фрукта
                        continue;
                    }
                    else
                    {
                        // вийти зпрограми
                        break;
                    }
                }

                // перевірка чи з'їдене яблуко
                if (fruits[0].ToLower() == s.ToLower())
                {
                    // перевірка чи це субота
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        // перевірка чи це час з 12:00 - 24:00
                        if (12 <= date.Hour && date.Hour <= 24)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\tВи отравилися і можете не вижити.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\n\tВи виживете.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\tВи виживете.");
                    }
                }
                else
                {
                    Console.WriteLine("\n\tВи виживете.");
                }

                // запитати чи хоче рористучач спробувати ще раз ввести дані
                {
                    Console.WriteLine("\n\tСпробувати ще раз ввести назву фрукта? [т, н]");

                    var button = Console.ReadKey(true);

                    if ((button.KeyChar.ToString().ToLower() == "т") ||
                        (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
                    {
                        // спроба знову ввести назву фрукта
                        continue;
                    }
                    else
                    {
                        // вийти зпрограми
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Шукати
        /// </summary>
        /// <param name="str"></param>
        public static bool Find(string str, string[] fruits)
        {
            // прапор чи щось найдено
            bool resFind = false;

            // переглядаємо список даних
            for (int i = 0; i < fruits.Length; i++)
            {
                // якщо співпадіння є то виводимо на екран
                if (fruits[i].ToLower() == str.ToLower())
                {
                    resFind |= true;
                }
            }

            // якщо результів не найшлось, виводимо сповіщення
            if (!resFind)
            {
                Console.WriteLine("\n\tТакий фрукт не найдено.");
            }

            return resFind;
        }

    }
}
