using System;
using System.IO;

namespace Ex3
{
    /// <summary>
    /// Структура содержащая в себе имя и пароли пользователей
    /// </summary>
    struct Account
    {
        private string[] Login;
        private string[] Password;
        public int NumOfUsers { get; set; }

/*        
        public Account()
        {
            ReadLoginPassword();           
        }
*/
        /// <summary>
        /// Метод считываеющий данные из файла и записывающий их в экземпляр
        /// </summary>
        /// <returns>Возарщает истину если считывание прошло успешно</returns>
        public bool ReadLoginPassword()
        {
            string filename = "Ex3_Users.txt";
            string[] allFile;
            string[] temp;
            if (File.Exists(filename))
            {
                //Считываем все строки в файл
                allFile = File.ReadAllLines(filename);
                NumOfUsers =allFile.Length;
                Login = new string[NumOfUsers];
                Password = new string[NumOfUsers];                
                for (int i = 0; i < NumOfUsers; i++)
                {
                    temp = allFile[i].Split(';');
                    if (temp.Length > 2)
                    {
                        Console.WriteLine("Ошибка чтения данных");
                        continue;
                    }
                    Login[i] = temp[0];
                    Password[i] = temp[1];
                }
                return true;
            }
            else
            {
                Login = null;
                Password = null;
                Console.WriteLine("Файл не найден");
                return false;
            }

        }

        /// <summary>
        /// Метод проверки вводимого логина и пароля с логином и паролем из экземпляра 
        /// </summary>
        /// <param name="Users">Экземпляр</param>
        /// <param name="inputLogin">Проверяемый логин</param>
        /// <param name="inputPassword">Проверяемый пароль</param>
        /// <returns>Возвращаент истину если найдено совпадение пары логин и пароль в экземпляре</returns>
        public static bool CheckLoginAndPassword(Account Users, string inputLogin, string inputPassword)
        {
            for (int i = 0; i < Users.NumOfUsers; i++)
            {
                if (inputLogin == Users.Login[i] && inputPassword == Users.Password[i])
                    return true;
            }
            return false;
        }                  
    }
}
