using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostOfficeSystem
{
    // Базовый класс Package
    public abstract class Package : IUrgent
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public DateTime SendDate { get; set; }
        protected double baseCost;
        public bool IsUrgent { get; set; }
        public double AdditionalCost { get; set; }

        public abstract double CalculateCost();

        public virtual double TotalCost => CalculateCost() + (IsUrgent ? AdditionalCost : 0);

        public override string ToString()
        {
            return $"Тип: {GetType().Name}, От: {Sender}, Кому: {Recipient}, Дата: {SendDate:dd.MM.yyyy}, " +
                   $"Стоимость: {TotalCost:F2} руб.{(IsUrgent ? " (Срочная)" : "")}";
        }
    }
}