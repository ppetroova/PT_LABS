using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем кодировку консоли для корректного отображения кириллицы
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== ТЕСТИРОВАНИЕ СИСТЕМЫ ПОЧТОВОГО ОТДЕЛЕНИЯ ===\n");

            // Создаем почтовое отделение
            var postOffice = new PostOffice();
            Console.WriteLine("Создано почтовое отделение.\n");

            // Создаем различные посылки
            var letter1 = new Letter("Иванов И.И.", "Петров П.П.", new DateTime(2024, 1, 15), 50);
            letter1.IsInternational = false;
            letter1.IsUrgent = true;

            var letter2 = new Letter("Сидоров С.С.", "Козлов К.К.", new DateTime(2024, 1, 20), 50);
            letter2.IsInternational = true;
            letter2.IsUrgent = false;

            var box1 = new Box("ООО 'Ромашка'", "ИП 'Василек'", new DateTime(2024, 1, 10), 200, 3.5);
            box1.IsUrgent = true;

            var box2 = new Box("АО 'Глобус'", "ЗАО 'Мир'", new DateTime(2024, 1, 5), 200, 8.2);
            box2.IsUrgent = false;

            var check1 = new Check("Смирнова А.А.", "Кузнецова Е.Е.", new DateTime(2024, 1, 25), 30, 5000);
            check1.IsUrgent = false;

            var check2 = new Check("Павлов В.В.", "Николаев Г.Г.", new DateTime(2024, 1, 18), 30, 15000);
            check2.IsUrgent = true;

            var check3 = new Check("Федоров Д.Д.", "Макаров С.С.", new DateTime(2024, 1, 22), 30, 8000);
            check3.IsUrgent = true;

            Console.WriteLine("Создано 7 различных посылок:\n");
            Console.WriteLine($"1. {letter1}");
            Console.WriteLine($"2. {letter2}");
            Console.WriteLine($"3. {box1}");
            Console.WriteLine($"4. {box2}");
            Console.WriteLine($"5. {check1}");
            Console.WriteLine($"6. {check2}");
            Console.WriteLine($"7. {check3}\n");

            // Тестируем прием посылок
            Console.WriteLine("=== ПРИЕМ ПОСЫЛОК В ОТДЕЛЕНИЕ ===");
            try
            {
                postOffice.ReceivePackage(letter1);
                postOffice.ReceivePackage(letter2);
                postOffice.ReceivePackage(box1);
                postOffice.ReceivePackage(box2);
                postOffice.ReceivePackage(check1);
                postOffice.ReceivePackage(check2);
                postOffice.ReceivePackage(check3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine();

            // Выводим информацию об отделении
            Console.WriteLine("=== ИНФОРМАЦИЯ О ПОЧТОВОМ ОТДЕЛЕНИИ ===");
            Console.WriteLine(postOffice);
            Console.WriteLine();

            // Тестируем расчет средней стоимости
            Console.WriteLine("=== РАСЧЕТ СРЕДНЕЙ СТОИМОСТИ ===");
            double avgCost = postOffice.CalculateAvgPackageCost();
            Console.WriteLine($"Средняя стоимость посылки в отделении: {avgCost:F2} руб.\n");

            // Тестируем отправку посылок
            Console.WriteLine("=== ОТПРАВКА ПОСЫЛОК ===");
            Console.WriteLine($"Количество посылок до отправки: {postOffice.PackageCount}");
            postOffice.SendPackage();
            Console.WriteLine($"Количество посылок после отправки: {postOffice.PackageCount}\n");
            // Отправляем еще одну
            Console.WriteLine("Отправляем еще одну посылку:");
            postOffice.SendPackage();
            Console.WriteLine($"Количество посылок после второй отправки: {postOffice.PackageCount}\n");

            // Выводим финальное состояние
            Console.WriteLine("=== ФИНАЛЬНОЕ СОСТОЯНИЕ ОТДЕЛЕНИЯ ===");
            Console.WriteLine(postOffice);
            Console.WriteLine($"Средняя стоимость оставшихся посылок: {postOffice.CalculateAvgPackageCost():F2} руб.\n");

            // Тестируем обработку ошибок
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ОШИБОК ===");
            try
            {
                var invalidPackage = new Letter("", "Получатель", DateTime.Now, 50);
                postOffice.ReceivePackage(invalidPackage);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }

            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
            Console.ReadKey();
        }
    }
}