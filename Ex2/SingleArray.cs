using System;
using System.IO;
using System.Linq;

/*
а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий
массив определенного размера и заполняющий массив числами от начального значения с
заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод
Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент
массива на определённое число, свойство MaxCount, возвращающее количество максимальных
элементов. В Main продемонстрировать работу класса.
б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в
файл

Выполнил Волков Кирилл
*/

namespace Ex2
{
    /// <summary>
    /// Класс работы с одномерными массивами
    /// </summary>
    class SingleArray
    {
        private int[] a; 
        Random rnd = new Random();

        /// <summary>
        /// Конструктор создающий n случайных элементов от -100 до 100
        /// </summary>
        /// <param name="n">количество элементов в массиве</param>
        public SingleArray(int n)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(-100, 100);
        }

        /// <summary>
        /// Конструктор считывающий массив из файла
        /// </summary>
        /// <param name="filename">имя файла</param>
        public SingleArray(string filename)
        {
            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки в файл
                string[] ss = File.ReadAllLines(filename);
                a = new int[ss.Length];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Error load file");
        }

        /// <summary>
        /// Конструктор создающий массив из n элементов где первый элемент задается, 
        /// а остальные элементы кратны шагу и начальному элементу
        /// </summary>
        /// <param name="n">Количество элементов</param>
        /// <param name="start">Начальное значение</param>
        /// <param name="step">Шаг созданиия оставшихся элементов от начального значения</param>
        public SingleArray (int n, int start, int step)
        {
            a = new int[n];
            for (int i = 0; i < a.Length; i++)
                a[i] = start + step * i;

        }

        /// <summary>
        /// Метод записи массива в файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <returns></returns>
        public bool WriteToFile(string filename)
        {
            try
            {
                File.WriteAllText(filename, Print());
                return true;
            }
            catch
            {
                Console.WriteLine("Error save file");
                return false;
            }
        }

        /// <summary>
        /// Максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                return a.Max();
            }
        }

        /// <summary>
        /// Длинна массива
        /// </summary>
        public int length
        {
            get
            {
                return a.Length;
            }
        }

        /// <summary>
        /// Метод умножающий элементы массива на заданое число
        /// </summary>
        /// <param name="x">Множитель</param>
        public void MultiBy(int x)
        {
            for(int i=0; i<length; i++)
            {
                this[i] *= x;
            }
        }

        /// <summary>
        /// Метод меняющий знак у элементов массива
        /// </summary>
        public void Invert()
        {
            for (int i = 0; i < length; i++)
            {
                this[i] *= -1;
            }
        }

        /// <summary>
        /// Метод посчета количества максимальных элементов массива
        /// </summary>
        /// <returns></returns>
        public int MaxCount1()
        {
            int MaxCount = 0;
            int Max = this.Max;
            for (int i = 0; i < length; i++)
            {
                if (Max == this[i])
                    MaxCount++;
            }
            return MaxCount;
        }

        /// <summary>
        /// Количество максимальных элементов массива
        /// </summary>
        public int MaxCount
        {
            get
            {
                return MaxCount1();
            }
        }

        /// <summary>
        /// Сумма элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                return a.Sum();
            }
        }

        /// <summary>
        /// Методы получения и установки значения элемента массива
        /// </summary>
        /// <param name="i">Номер элемента массива</param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return a[i]; }

            set { a[i] = value; }
        }

        /// <summary>
        /// Метод возвращающий массив в виде строки
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            string array = "";
            foreach (int el in a)
                array = array + el + " ";
//                Console.Write(array);
            return array;
        }
    }
}


