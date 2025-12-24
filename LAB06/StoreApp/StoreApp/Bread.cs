using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApp
{
    public class Bread : Product
    {
        public string Type { get; set; } // Пшеничный, ржаной и т.д.

        public Bread(string name, double price, DateTime arrival, DateTime expiry, string type)
            : base(name, price, arrival, expiry)
        {
            Type = type;
        }

        protected override void CalculateDiscount()
        {
            Discount = DaysUntilExpiry() == 0 ? 50.0 : // испорчен – 50%
                       DaysUntilExpiry() <= 1 ? 30.0 : // 1 день – 30%
                       0.0;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Тип: {Type}";
        }
    }
}