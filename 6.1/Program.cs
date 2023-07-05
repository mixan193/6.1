using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBHandler dBHandler = new DBHandler("DB.txt");
            int id;
            DateTime dateTime;
            string fullName;
            int height;
            DateTime dateOfBirth;
            string placeOfBirth;
            while (true)
            {
                id = dBHandler.GetLastID();
                dateTime = DateTime.Now;
                Console.WriteLine("Введите ФИО ");
                fullName = EnterString();
                Console.WriteLine("Введите рост ");
                height = EnterInt();
                Console.WriteLine("Введите дату рождения ");
                dateOfBirth = EnterDate();
                Console.WriteLine("Введите место рождения ");
                placeOfBirth = EnterString();
                Employee employer = new Employee(id, dateTime, fullName, height, dateOfBirth, placeOfBirth);
                dBHandler.AddEmployerToDB(employer.EmployerToString());
            }
        }

        private static string EnterString()
        {
            string result;
            while ((result = Console.ReadLine()) == string.Empty)
            {
                Console.WriteLine("Вы ничего не ввели");
            }
            return result;
        }

        private static int EnterInt()
        {
            int result = 0;
            while(result < 1)
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число");
                }
            }
            return result;
        }

        private static DateTime EnterDate()
        {
            DateTime result = new DateTime();
            string dateOfBirdthInString;
            bool isAccepted = false;
            while (!isAccepted)
            {
                try
                {
                    dateOfBirdthInString = Console.ReadLine();
                    string[] strings = dateOfBirdthInString.Split('.');
                    result = new DateTime(int.Parse(strings[2]), int.Parse(strings[1]), int.Parse(strings[0]));
                    isAccepted = true;
                }
                catch
                {
                    Console.WriteLine("Введите дату в формате день.месяц.год");
                }
            }
            return result;
        }

    }
}
