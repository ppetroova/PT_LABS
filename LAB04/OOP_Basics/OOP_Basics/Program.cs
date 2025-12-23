using System;

namespace DateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тест 1
            try
            {
                Date date1 = new Date(2023, 2, 29); // Невозможная дата (в 2023 году нет 29 февраля)
                date1.PrintDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
            }

            // Тест 2
            try
            {
                Date date2 = new Date(2024, 2, 29); // Корректная дата (в 2024 году 29 февраля)
                date2.PrintDate();

                date2.AddDays(5); // Добавим 5 дней
                date2.PrintDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
            }

            // Тест 3
            try
            {
                Date date3 = new Date(2023, 4, 31); // Невозможная дата (в апреле 31-го не бывает)
                date3.PrintDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
            }

            // Тест 4
            try
            {
                Date date4 = new Date(2025, 12, 15); // Правильная дата
                date4.PrintDate();
                date4.AddDays(20); // Добавим 20 дней
                date4.PrintDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
