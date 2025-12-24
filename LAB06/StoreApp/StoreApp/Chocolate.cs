using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApp
{
    public class Chocolate : Product
    {
        public bool IsDark { get; set; } // Тёмный или молочный

        public Chocolate(string name, double price, DateTime arrival, DateTime expiry, bool isDark)
            : base(name, price, arrival, expiry)
        {
            IsDark = isDark;
        }

        protected override void CalculateDiscount()
        {
            // Шоколад почти не портится → скидка только если просрочен
            Discount = DaysUntilExpiry() == 0 ? 15.0 :
                       0.0;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Тип: {(IsDark ? "Тёмный" : "Молочный")}";
        }
    }
}