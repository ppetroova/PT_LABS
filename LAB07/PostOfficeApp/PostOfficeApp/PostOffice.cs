using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostOfficeSystem
{
    // Класс почтового отделения
    public class PostOffice
    {
        private List<Package> packages = new List<Package>();

        public void ReceivePackage(Package p)
        {
            if (string.IsNullOrWhiteSpace(p.Sender) || string.IsNullOrWhiteSpace(p.Recipient))
            {
                throw new ArgumentException("Посылка должна иметь отправителя и получателя!");
            }

            packages.Add(p);
            Console.WriteLine($"Принята посылка: {p}");
        }

        public void SendPackage()
        {
            if (packages.Count == 0)
            {
                Console.WriteLine("В отделении нет посылок для отправки!");
                return;
            }

            // Находим самую старую посылку
            var oldestPackage = packages.OrderBy(p => p.SendDate).First();
            packages.Remove(oldestPackage);

            Console.WriteLine($"Отправлена самая старая посылка: {oldestPackage}");
        }

        public double CalculateAvgPackageCost()
        {
            if (packages.Count == 0)
            {
                return 0;
            }

            return packages.Average(p => p.TotalCost);
        }

        public override string ToString()
        {
            if (packages.Count == 0)
            {
                return "В почтовом отделении нет посылок.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Почтовое отделение. Всего посылок: {packages.Count}");
            sb.AppendLine("Список посылок (отсортирован по типу):");

            // Сортируем по типу посылки
            var sortedPackages = packages.OrderBy(p => p.GetType().Name);
            foreach (var package in sortedPackages)
            {
                sb.AppendLine($"  - {package}");
            }

            return sb.ToString();
        }

        public int PackageCount => packages.Count;
    }
}