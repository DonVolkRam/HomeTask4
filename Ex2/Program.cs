using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class Program
    {
        static void Main(string[] args)
        {
            SingleArray array1 = new SingleArray(10);
            string filename1 = "array.txt";
            string filename2 = "ReadArray.txt";

            Console.WriteLine("Создание массива из случайных элементов");
            Console.WriteLine(array1.Print());
            Console.WriteLine("Изменение знака элементов ");
            array1.Invert();
            Console.WriteLine(array1.Print());
            Console.WriteLine("Максимальный элемент: " + array1.Max);            
            Console.WriteLine("array[3]: " + array1[3]);
            Console.WriteLine("Запись в каталог с исполняемым файлом в " + filename1);
            array1.WriteToFile(filename1);

            Console.WriteLine("\nСоздание массива из 10 элементов с начальным значением 0 и шагом 3");
            SingleArray array2 = new SingleArray(10, 0, 3);
            Console.WriteLine(array2.Print());
            Console.WriteLine("Перемножение элементов на 4 ");
            array2.MultiBy(4);
            Console.WriteLine(array2.Print());

            Console.WriteLine("\nЧтение  массива из файла в каталоге с исполняемым файлом " + filename2);
            SingleArray array3 = new SingleArray(filename2);
            Console.WriteLine(array3.Print());
            Console.WriteLine("Количество максимальных элементов: " + array3.MaxCount);
            Console.WriteLine("Сумма элементов массива = " + array3.Sum);
            Console.ReadKey();
        }
    }
}


