using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class MyArrayList
    {
        /// <summary>
        /// Масив елементів
        /// </summary>
        private object[] array = new object[4];
        /// <summary>
        /// Кількість доданих елементів
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity { get { return array.Length; } }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="newSize"></param>
        private void Resize(int newSize)
        {
            // новий масив елементів - іншого розміру
            var temp = new object[newSize];
            // копіювання даних з зовнішнього масиву
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }
            // змінна ссилки на масив
            array = temp;
        }

        /// <summary>
        /// Індексатор доступу до елементів
        /// </summary>
        /// <param name="index">індекс елемента</param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                    return default;
                }
            }
            set
            {
                try
                {
                    array[index] = value;
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Додавання елемнтів масивом
        /// </summary>
        /// <param name="value">Масив вхідних значень</param>
        public void AddRange(params object[] value)
        {
            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2) 
            #endregion

            // щоб даремно не виконувати лишні операції,
            // то краще перевірити чи щось було передано
            if (value.Length < 1)
            {
                return;
            }

            // зміна розмірів, якщо необхідно
            if (Count + value.Length == Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2)) + 1));
            }
            else if (Count + value.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2))));
            }

            // присвоєння значень
            for (int i = 0; i < value.Length; i++)
            {
                array[Count] = value[i];
                Count++;
            }
        }

        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        /// <param name="value"></param>
        public void Add(object value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Відображення рядка в кольорі
        /// </summary>
        /// <param name="s">рядок</param>
        /// <param name="color">колір</param>
        private static void Show(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }

    }
}
