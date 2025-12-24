using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PostOfficeSystem
{
    // Интерфейс для срочных посылок
    public interface IUrgent
    {
        double AdditionalCost { get; }
        bool IsUrgent { get; set; }
    }
}