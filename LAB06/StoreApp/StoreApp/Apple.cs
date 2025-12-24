using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApp
{
    public class Apple : Product
    {
        public string Variety { get; set; } // Сорт: Гала, Фуджи и т.д.

        public Apple(string name, double price, DateTime arrival, DateTime expiry, string variety)
            : base(name, price, arrival, expiry)
        {
            Variety = variety;
        }

        protected override void CalculateDiscount()
        {
            Discount = DaysUntilExpiry() == 0 ? 25.0 : // только в день окончания
                       0.0;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Сорт: {Variety}";
        }
    }
}