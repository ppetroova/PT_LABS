using System;
using System.Collections.Generic;
using System;

namespace PostOfficeSystem
{
    // Класс Check - денежный перевод/чек
    public class Check : Package
    {
        public double Amount { get; set; } // сумма перевода

        public Check(string sender, string recipient, DateTime sendDate, double baseCost, double amount)
        {
            Sender = sender;
            Recipient = recipient;
            SendDate = sendDate;
            this.baseCost = baseCost;
            Amount = amount;
            AdditionalCost = 50; // Доплата за срочность для чека
        }

        public override double CalculateCost()
        {
            double cost = baseCost;
            if (Amount > 10000)
            {
                cost += Amount * 0.01; // 1% от суммы сверх 10000
            }
            return cost;
        }

        public override string ToString()
        {
            return base.ToString() + $", Сумма: {Amount:F2} руб.";
        }
    }
}