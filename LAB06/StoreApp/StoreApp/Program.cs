using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Текущая дата — для реалистичного расчёта скидок
            DateTime today = new DateTime(2025, 4, 10);

            // Массив из 10 товаров
            Product[] products = new Product[]
            {
                new Bread("Батон нарезной", 15.0, today.AddDays(-2), today.AddDays(1), "Пшеничный"),
                new Bread("Ржаной хлеб", 20.0, today.AddDays(-1), today, "Ржаной"),
                new Milk("Молоко 3.2%", 80.0, today.AddDays(-3), today.AddDays(2), 1.0),
                new Milk("Домик в деревне", 95.0, today.AddDays(-5), today.AddDays(1), 0.95),
                new Apple("Яблоки Гала", 120.0, today.AddDays(-10), today.AddDays(5), "Гала"),
                new Apple("Яблоки Фуджи", 130.0, today.AddDays(-7), today, "Фуджи"),
                new Chocolate("Алёнка", 70.0, today.AddDays(-30), today.AddDays(365), true),
                new Chocolate("Milka", 110.0, today.AddDays(-20), today.AddDays(180), false),
                new Bread("Багет", 25.0, today.AddDays(-1), today.AddDays(-1), "Французский"), // просрочен
                new Milk("Простоквашино", 85.0, today.AddDays(-4), today.AddDays(0), 1.0)   // сегодня окончание
            };

            Console.WriteLine("=== Все товары в магазине ===");
            double totalCost = 0;
            Product maxDiscountProduct = products[0];

            foreach (var product in products)
            {
                Console.WriteLine(product);
                totalCost += product.GetPriceWithDiscount();

                if (product.Discount > maxDiscountProduct.Discount)
                    maxDiscountProduct = product;
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine($"Общая стоимость всех товаров со скидками: {totalCost:F2} ₽");
            Console.WriteLine($"Товар с максимальной скидкой:\n{maxDiscountProduct}");
        }
    }
}
