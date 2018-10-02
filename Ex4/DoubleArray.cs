using System;
using System.Linq;
using System.IO;

namespace Ex4
{
    /// <summary>
    /// Класс работы с двумерными массивами
    /// </summary>
    class DoubleArray
    {
        private int[,] a;
        private int Row { get; set; }
        private int Col { get; set; }


        /// <summary>
        /// Конструктор заполняющий случайными числами элементы массива от -100 до 100
        /// </summary>
        /// <param name="row">Количество строк в массиве</param>
        /// <param name="col">Количество столбцов в массиве</param>
        public DoubleArray(int row, int col)
        {
            a = new int[row, col];
            Row = row;
            Col = col;
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    a[i, j] = rnd.Next(-100, 100);
        }

        /// <summary>
        /// Конструктор считывающий массив из файла
        /// </summary>
        /// <param name="filename">имя файла</param>
        public DoubleArray(string filename)
        {            
            if (File.Exists(filename))
            {              
                string[] ss = File.ReadAllLines(filename);
                string[] row = ss[0].Split(' ');
                Row = ss.Length;
                Col = row.Length - 1;

                a = new int[Row, Col];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < Row; i++)
                {
                    row = ss[i].Split(' ');
                    for (int j = 0; j < Col; j++)                       
                        a[i,j] = int.Parse(row[j]);
                }

            }
            else Console.WriteLine("Error load file");
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
                File.WriteAllText(filename, ToFile());
                return true;
            }
            catch
            {
                Console.WriteLine("Error save file");
                return false;
            }
        }

        /// <summary>
        /// Минмальный элемент массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = a[0, 0];
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }

        /// <summary>
        /// Максимальный элемент
        /// </summary>
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }

        /// <summary>
        /// Сумма элементов массива
        /// </summary>
        public int Summ()
        {
            int summ = 0;
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    summ += a[i, j];

            return summ;            
        }

        /// <summary>
        /// Сумма элементов массива больше заданного
        /// </summary>
        /// <param name="value">Значение больше которого будет считаться сумма</param>
        public int Summ(int value)
        {
            int summ = 0;
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    if (a[i,j] > value)
                        summ += a[i, j];
            return summ;
        }

        /// <summary>
        /// Методы получения и установки значения элемента массива
        /// </summary>
        /// <param name="i">Номер строки элемента массива</param>
        /// <param name="j">Номер колонки элемента массива</param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get { return a[i,j]; }

            set { a[i,j] = value; }
        }

        /// <summary>
        /// Метод возвращающий массив в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                    s += $"{a[i, j], 4}" +  " ";
                s += "\n";
            }
            return s;
        }

        /// <summary>
        /// Метод возвращающий массив в виде строки для записи в файл
        /// </summary>
        /// <returns></returns>
        public string ToFile()
        {
            string s = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                    s += a[i, j] + " ";
                s += "\n";
            }
            return s;
        }
    }
}
