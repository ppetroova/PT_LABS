using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApp
{
    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual double Discount { get; protected set; }

        public Product(string name, double price, DateTime arrival, DateTime expiry)
        {
            ProductName = name;
            Price = price;
            ArrivalDate = arrival;
            ExpiryDate = expiry;
            CalculateDiscount(); // инициализация скидки при создании
        }

        // Количество дней до окончания срока годности
        public int DaysUntilExpiry()
        {
            return Math.Max(0, (ExpiryDate - DateTime.Today).Days);
        }

        // Виртуальный метод для расчёта скидки (перекрывается в наследниках)
        protected virtual void CalculateDiscount()
        {
            // По умолчанию: 0% скидка
            Discount = 0.0;
        }

        // Цена со скидкой
        public double GetPriceWithDiscount()
        {
            return Price * (1 - Discount / 100);
        }

        public override string ToString()
        {
            return $"{ProductName} | Цена: {Price:F2} ₽ | Скидка: {Discount:F1}% | До окончания: {DaysUntilExpiry()} дн.";
        }
    }
}