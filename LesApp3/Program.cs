using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
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
            apple,
            /// <summary>
            /// Груша
            /// </summary>
            pear,
            /// <summary>
            /// Слива
            /// </summary>
            plum,
            /// <summary>
            /// Абрикос
            /// </summary>
            apricot,
            /// <summary>
            /// Персик
            /// </summary>
            peach
        }
        /// <summary>
        /// Овочі
        /// </summary>
        enum Vegetables
        {
            /// <summary>
            /// Помідор
            /// </summary>
            tomato,
            /// <summary>
            /// Огірок
            /// </summary>
            cucumber,
            /// <summary>
            /// Морква
            /// </summary>
            carrot,
            /// <summary>
            /// Картопля
            /// </summary>
            potato,
            /// <summary>
            /// Перець
            /// </summary>
            pepper
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
            string[] vegetables = Enum
                .GetValues(typeof(Vegetables))
                .Cast<Vegetables>()
                .Select(t => t.ToString())
                .ToArray();

            // користувач вводить дані
            Console.Write("\n\tВведіть назву фрукта чи овоча: ");
            string s = Console.ReadLine();

            // аналіз введених даних
            Find(s, fruits, vegetables);

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

        /// <summary>
        /// Шукати далі
        /// </summary>
        /// <param name="str"></param>
        public static void Find(string str, string[] fruits, string[] vegetables)
        {
            // прапор чи щось найдено
            bool resFind = false;

            // переглядаємо список даних
            for (int i = 0; i < fruits.Length; i++)
            {
                // якщо співпадіння є то виводимо на екран
                if (fruits[i].ToLower() == str.ToLower())
                {
                    Console.WriteLine("\n\tЙмовірніше Ви варите кампот.");
                    resFind |= true;
                }
            }

            for (int i = 0; i < vegetables.Length; i++)
            {
                // якщо співпадіння є то виводимо на екран
                if (vegetables[i].ToLower() == str.ToLower())
                {
                    Console.WriteLine("\n\tЙмовірніше Ви варите борщ.");
                    resFind |= true;
                }
            }

            // якщо результів не найшлось, виводимо сповіщення
            if (!resFind)
            {
                Console.WriteLine("\n\tЙмовірніше Ви нічого не варите.");
            }
        }

    }
}
