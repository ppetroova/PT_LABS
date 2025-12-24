using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApp
{
    public class Milk : Product
    {
        public double VolumeLiters { get; set; } // Объём в литрах

        public Milk(string name, double price, DateTime arrival, DateTime expiry, double volume)
            : base(name, price, arrival, expiry)
        {
            VolumeLiters = volume;
        }

        protected override void CalculateDiscount()
        {
            Discount = DaysUntilExpiry() == 0 ? 70.0 : // испорчен – 70%
                       DaysUntilExpiry() <= 1 ? 40.0 : // 1 день – 40%
                       DaysUntilExpiry() <= 2 ? 20.0 : // 2 дня – 20%
                       0.0;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Объём: {VolumeLiters} л";
        }
    }
}