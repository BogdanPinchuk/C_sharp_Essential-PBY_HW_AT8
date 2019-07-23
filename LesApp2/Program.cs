using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        /// <summary>
        /// Професії
        /// </summary>
        // https://www.passion.ru/career/vasha-karera/top-10-samyh-vostrebovannyh-professiy-62003.htm
        enum Profesion
        {
            /// <summary>
            /// Інженер
            /// </summary>
            Engineer,
            /// <summary>
            /// ІТ-спеціаліст
            /// </summary>
            ITspecialist,
            /// <summary>
            /// Медик
            /// </summary>
            Medic,
            /// <summary>
            /// Еколог
            /// </summary>
            Ecologist,
            /// <summary>
            /// Хімік
            /// </summary>
            Chemist
        }

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // конвертуємо перерахунки в масив
            string[] array = Enum
                .GetValues(typeof(Profesion))
                .Cast<Profesion>()
                .Select(t => t.ToString())
                .ToArray();

            // користувач вводить дані
            Console.Write("\n\tВведіть назву професії для пошуку " +
                "наявності її в списку: ");
            string s = Console.ReadLine();

            // пошук в списку по співпадінню, 
            Find(s, array);

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
        /// Шукати
        /// </summary>
        /// <param name="str"></param>
        public static void Find(string str, string[] array)
        {
            // прапор чи щось найдено
            bool resFind = false;

            // переглядаємо список даних
            for (int i = 0; i < array.Length; i++)
            {
                // якщо співпадіння є то виводимо на екран
                if (array[i].ToLower() == str.ToLower())
                {
                    resFind |= true;
                }
            }

            // якщо результів не найшлось, виводимо сповіщення
            if (resFind)
            {
                Console.WriteLine("\n\tДана професія наявна в списку.");
            }
            else
            {
                Console.WriteLine("\n\tДана професія відсутня в списку.");
            }
        }

    }
}
