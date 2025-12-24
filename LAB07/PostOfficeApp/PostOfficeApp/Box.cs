using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostOfficeSystem
{
    // Класс Box - коробка
    public class Box : Package
    {
        public double Weight { get; set; } // вес в кг

        public Box(string sender, string recipient, DateTime sendDate, double baseCost, double weight)
        {
            Sender = sender;
            Recipient = recipient;
            SendDate = sendDate;
            this.baseCost = baseCost;
            Weight = weight;
            AdditionalCost = 200; // Доплата за срочность для коробки
        }

        public override double CalculateCost()
        {
            double cost = baseCost;
            if (Weight > 5)
            {
                cost += (Weight - 5) * 50; // Доплата за каждый кг сверх 5 кг
            }
            return cost;
        }

        public override string ToString()
        {
            return base.ToString() + $", Вес: {Weight:F1} кг";
        }
    }
}