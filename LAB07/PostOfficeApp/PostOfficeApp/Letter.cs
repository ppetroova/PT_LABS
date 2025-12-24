using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeSystem
{
    // Класс Letter - письмо
    public class Letter : Package
    {
        public bool IsInternational { get; set; }

        public Letter(string sender, string recipient, DateTime sendDate, double baseCost)
        {
            Sender = sender;
            Recipient = recipient;
            SendDate = sendDate;
            this.baseCost = baseCost;
            AdditionalCost = 100; // Доплата за срочность для письма
        }

        public override double CalculateCost()
        {
            double cost = baseCost;
            if (IsInternational)
            {
                cost *= 1.5; // На 50% дороже международные письма
            }
            return cost;
        }

        public override string ToString()
        {
            return base.ToString() + $", Международное: {IsInternational}";
        }
    }
}