using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
*а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор,
заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех
элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее
минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
метод, возвращающий номер максимального элемента массива (через параметры, используя
модификатор ref или out).
**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные
в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.

выполнил Волков Кирилл
*/

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание массива 15 на 10");
            DoubleArray Arr = new DoubleArray(15, 10);
            Console.WriteLine(Arr.ToString());
            Console.WriteLine("Запись в файл Array.txt");
            Arr.WriteToFile("Array.txt");

            Console.WriteLine("Чтение из файла Array.txt");
            DoubleArray Array = new DoubleArray("Array.txt");
            Console.WriteLine(Array.ToString());

            Console.WriteLine("Сумма всех элементов = {0}", Array.Summ());
            Console.WriteLine("Сумма всех элементов больше 0 = {0}", Array.Summ(0));
            Console.WriteLine("Минимальный элемент {0}\n" +
                              "Максимальный элемент {1}", Array.Min, Array.Max);
            Console.Read();
        }
    }
}
