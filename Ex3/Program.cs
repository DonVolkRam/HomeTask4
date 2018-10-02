using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.

выполнил Волков Кирилл
*/

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация базы пользователей");
            try
            {
                Account Users = new Account();
                if(Users.ReadLoginPassword()==false) 
                    throw new Exception("Error load file");
                string login;
                string password;
                bool check = false;
                int tryIndex = 3;
                do
                {
                    if (tryIndex < 3)
                        Console.WriteLine("Пара логин и пароль не верна ", tryIndex);
                   
                    Console.Write("Введите логин ");
                    login = Convert.ToString(Console.ReadLine());
                    Console.Write("Введите пароль ");
                    password = Convert.ToString(Console.ReadLine());

                    tryIndex--;
                }
                while (!(check = Account.CheckLoginAndPassword(Users, login, password)) && tryIndex > 0);
                if (check)
                    Console.WriteLine("Добро пожаловать!");
                else
                    Console.WriteLine("Доступ запрещен!");
            }
            catch
            {
                Console.WriteLine("Ошибка инициализации");              
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
