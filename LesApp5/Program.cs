using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp5
{
    class Program
    {
        /// <summary>
        /// Тропічний зодіак
        /// </summary>
        // https://uk.wikipedia.org/wiki/Зодіак
        enum Zodiac
        {
            /// <summary>
            /// Овен 21 березня — 20 квітня
            /// </summary>
            Aries,
            /// <summary>
            /// Телець 21 квітня — 21 травня
            /// </summary>
            Taurus,
            /// <summary>
            /// Близнята 22 травня — 21 червня
            /// </summary>
            Gemini,
            /// <summary>
            /// Рак 22 червня — 22 липня
            /// </summary>
            Cancer,
            /// <summary>
            /// Лев 23 липня — 23 серпня
            /// </summary>
            Leo,
            /// <summary>
            /// Діва 24 серпня — 22 вересня
            /// </summary>
            Virgo,
            /// <summary>
            /// Терези 23 вересня — 23 жовтня
            /// </summary>
            Libra,
            /// <summary>
            /// Скорпіон 24 жовтня — 22 листопада
            /// </summary>
            Scorpio,
            /// <summary>
            /// Стрілець 23 листопада — 21 грудня
            /// </summary>
            Sagittarius,
            /// <summary>
            /// Козеріг 22 грудня — 20 січня
            /// </summary>
            Capricorn,
            /// <summary>
            /// Водолій 21 січня — 20 лютого
            /// </summary>
            Aquarius,
            /// <summary>
            /// Риби 21 лютого — 20 березня
            /// </summary>
            Pisces
        }

        /// <summary>
        /// Китайський зодіак
        /// </summary>
        // https://uk.wikipedia.org/wiki/Китайський_зодіак
        enum ChineseZodiac
        {
            /// <summary>
            /// Щур/миша
            /// </summary>
            Rat,
            /// <summary>
            /// Бик
            /// </summary>
            Ox,
            /// <summary>
            /// Тигр
            /// </summary>
            Tiger,
            /// <summary>
            /// Кролик
            /// </summary>
            Rabbit,
            /// <summary>
            /// Дракон
            /// </summary>
            Dragon,
            /// <summary>
            /// Змія
            /// </summary>
            Snake,
            /// <summary>
            /// Кінь
            /// </summary>
            Horse,
            /// <summary>
            /// Вівця/коза
            /// </summary>
            Goat_Sheep,
            /// <summary>
            /// Мавпа
            /// </summary>
            Monkey,
            /// <summary>
            /// Півень
            /// </summary>
            Rooster,
            /// <summary>
            /// Собака
            /// </summary>
            Dog,
            /// <summary>
            /// Свиня
            /// </summary>
            Pig
        }

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // введення дати
            Console.Write("\n\tВведіть дату дня народження: ");
            string s = Console.ReadLine();

            // конвертуємо рядок в дату
            bool error = DateTime.TryParse(s, out DateTime date);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            // тестування
            //date = new DateTime(1992, 01, 05);

            // аналіз дати по знакам зодіаку
            Console.WriteLine($"\n\tВаш знак зодіаку: {AnalizeZodiac(date)}");

            Console.WriteLine($"\n\tВаш знак китайського зодіаку: {AnalizeChineseZodiac(date)}");

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Визначення знаку зодіаку по даті дня народження
        /// </summary>
        /// <param name="date">Дата народження</param>
        /// <returns></returns>
        private static Zodiac AnalizeZodiac(DateTime date)
        {
            // змінна знаку зодіаку
            Zodiac zodiac = default;

            // конвертуємо перерахунки в масив
            var sign = Enum
                .GetValues(typeof(Zodiac))
                .Cast<Zodiac>()
                .ToArray();

            // аналіз
            if (new DateTime(date.Year, 03, 21) <= date &&
                date <= new DateTime(date.Year, 04, 20))
            {
                // Овен 21 березня — 20 квітня
                zodiac = sign[0];
            }
            else if (new DateTime(date.Year, 04, 21) <= date &&
                date <= new DateTime(date.Year, 05, 21))
            {
                // Телець 21 квітня — 21 травня
                zodiac = sign[1];
            }
            else if (new DateTime(date.Year, 05, 22) <= date &&
                date <= new DateTime(date.Year, 06, 21))
            {
                // Близнята 22 травня — 21 червня
                zodiac = sign[2];
            }
            else if (new DateTime(date.Year, 06, 22) <= date &&
                date <= new DateTime(date.Year, 07, 22))
            {
                // Рак 22 червня — 22 липня
                zodiac = sign[3];
            }
            else if (new DateTime(date.Year, 07, 23) <= date &&
                date <= new DateTime(date.Year, 08, 23))
            {
                // Лев 23 липня — 23 серпня
                zodiac = sign[4];
            }
            else if (new DateTime(date.Year, 08, 24) <= date &&
                date <= new DateTime(date.Year, 09, 22))
            {
                // Діва 24 серпня — 22 вересня
                zodiac = sign[5];
            }
            else if (new DateTime(date.Year, 09, 23) <= date &&
                date <= new DateTime(date.Year, 10, 23))
            {
                // Терези 23 вересня — 23 жовтня
                zodiac = sign[6];
            }
            else if (new DateTime(date.Year, 10, 24) <= date &&
                date <= new DateTime(date.Year, 11, 22))
            {
                // Скорпіон 24 жовтня — 22 листопада
                zodiac = sign[7];
            }
            else if (new DateTime(date.Year, 11, 23) <= date &&
                date <= new DateTime(date.Year, 12, 21))
            {
                // Стрілець 23 листопада — 21 грудня
                zodiac = sign[8];
            }
            else if (new DateTime(date.Year, 12, 22) <= date ||
                date <= new DateTime(date.Year, 01, 20))
            {
                // Козеріг 22 грудня — 20 січня
                zodiac = sign[9];
            }
            else if (new DateTime(date.Year, 01, 21) <= date &&
                date <= new DateTime(date.Year, 02, 20))
            {
                // Водолій 21 січня — 20 лютого
                zodiac = sign[10];
            }
            else if (new DateTime(date.Year, 02, 21) <= date &&
                date <= new DateTime(date.Year, 03, 20))
            {
                // Риби 21 лютого — 20 березня
                zodiac = sign[11];
            }

            return zodiac;
        }

        private static ChineseZodiac AnalizeChineseZodiac(DateTime date)
        {
            // змінна знаку зодіаку
            ChineseZodiac zodiac = default;

            // конвертуємо перерахунки в масив
            var sign = Enum
                .GetValues(typeof(ChineseZodiac))
                .Cast<ChineseZodiac>()
                .ToArray();

            #region Explain
            // алгоритм доволы простий
            // якщо уважно глянути, то знакыв всього 12,
            // і вони періодично змінюються кожного року
            // якщо не вдаватися в деталі крайніх чисел і приймати
            // знак знюється з 1 січня і триває до 31 грудня
            // то цей алгоритм схожий на визначення парності числа
            // а тому після знаходження залишку від діленння року на 12
            // можна визначити якого китайського знаку зодіаку людина родилася 
            #endregion

            // залишок від ділення
            int mod = date.Year % 12;

            switch (mod)
            {
                case 0:
                    // Мавпа
                    zodiac = sign[8];
                    break;
                case 1:
                    // Півень
                    zodiac = sign[9];
                    break;
                case 2:
                    // Собака
                    zodiac = sign[10];
                    break;
                case 3:
                    // Свиня
                    zodiac = sign[11];
                    break;
                case 4:
                    // Щур/миша
                    zodiac = sign[0];
                    break;
                case 5:
                    // Бик
                    zodiac = sign[1];
                    break;
                case 6:
                    // Тигр
                    zodiac = sign[2];
                    break;
                case 7:
                    // Кролик
                    zodiac = sign[3];
                    break;
                case 8:
                    // Дракон
                    zodiac = sign[4];
                    break;
                case 9:
                    // Змія
                    zodiac = sign[5];
                    break;
                case 10:
                    // Кінь
                    zodiac = sign[6];
                    break;
                case 11:
                    // Вівця/коза
                    zodiac = sign[7];
                    break;
            }

            return zodiac;
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
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }
    }
}
