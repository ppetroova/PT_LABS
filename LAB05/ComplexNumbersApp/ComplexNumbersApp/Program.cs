using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexNumbersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Тестирование класса Complex ===\n");

            // Создание двух комплексных чисел
            Complex z1 = new Complex(3.0, 4.0);    // 3 + 4i
            Complex z2 = new Complex(1.0, -2.0);   // 1 - 2i

            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}");
            Console.WriteLine();

            // Проверка свойств (чтение и запись)
            Console.WriteLine("=== Тестирование свойств ===");
            Console.WriteLine($"Действительная часть z1: {z1.Real}");
            Console.WriteLine($"Мнимая часть z1: {z1.Imaginary}");

            z1.Real = 5.0;
            z1.Imaginary = -1.0;
            Console.WriteLine($"После изменения: z1 = {z1}");
            Console.WriteLine();

            // Восстановим исходные значения для тестирования операций
            z1 = new Complex(3.0, 4.0);
            z2 = new Complex(1.0, -2.0);

            // Тестирование арифметических операций
            Console.WriteLine("=== Арифметические операции ===");
            Console.WriteLine($"z1 + z2 = {z1 + z2}");
            Console.WriteLine($"z1 - z2 = {z1 - z2}");
            Console.WriteLine($"z1 * z2 = {z1 * z2}");
            Console.WriteLine($"z1 / z2 = {z1 / z2}");
            Console.WriteLine();

            // Тестирование сравнения
            Console.WriteLine("=== Тестирование сравнения ===");
            Complex z3 = new Complex(3.0, 4.0);
            Console.WriteLine($"z1 == z3: {z1.Equals(z3)}");  // True
            Console.WriteLine($"z1 == z2: {z1.Equals(z2)}");  // False
            Console.WriteLine();

            // Тестирование деления на ноль
            Console.WriteLine("=== Попытка деления на ноль ===");
            Complex zero = new Complex(0, 0);
            try
            {
                Complex result = z1 / zero;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}