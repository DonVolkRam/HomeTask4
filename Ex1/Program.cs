using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые
значения от –10 000 до 10 000 включительно. Написать программу, позволяющую найти и
вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. В
данной задаче под парой подразумевается два подряд идущих элемента массива. Например,
для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 4.

Выполнил Волков Кирилл
*/

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 20;
            int[] array = new int[index];
            Random rnd = new Random(); 
            int count3 = 0;
            Console.WriteLine("Создаем массив из 20 элементов\n");
            for (int i = 0; i < index; i++)
            {
                array[i] = rnd.Next(-10000, 10000);
                Console.Write($"{array[i],6}");
                if(i%10==9)
                    Console.WriteLine("\n");
            }
            for (int i = 0; i < index - 1; i++)
            {
                if (array[i]%3==0 || array[i+1] % 3 == 0)
                {
                    count3++;
                    Console.WriteLine("Пара №{0,3} : {1,5} ; {2,5} ", count3, array[i], array[i + 1]);                   
                }
            }

            Console.WriteLine("\nКоличество пар = {0}", count3);
            Console.Read();
        }
    }
}
