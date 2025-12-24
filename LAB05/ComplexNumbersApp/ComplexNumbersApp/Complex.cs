using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexNumbersApp
{
    /// <summary>
    /// Класс для представления комплексного числа вида a + bi.
    /// </summary>
    public class Complex
    {
        // Приватные поля для хранения действительной и мнимой частей
        private double _real;
        private double _imaginary;

        // Свойства с публичным доступом для чтения и записи
        public double Real
        {
            get => _real;
            set => _real = value;
        }

        public double Imaginary
        {
            get => _imaginary;
            set => _imaginary = value;
        }

        /// <summary>
        /// Конструктор для создания комплексного числа.
        /// </summary>
        /// <param name="real">Действительная часть</param>
        /// <param name="imaginary">Мнимая часть</param>
        public Complex(double real = 0.0, double imaginary = 0.0)
        {
            _real = real;
            _imaginary = imaginary;
        }

        // Перегрузка оператора сложения
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1._real + c2._real, c1._imaginary + c2._imaginary);
        }

        // Перегрузка оператора вычитания
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1._real - c2._real, c1._imaginary - c2._imaginary);
        }

        // Перегрузка оператора умножения: (a + bi)(c + di) = (ac - bd) + (ad + bc)i
        public static Complex operator *(Complex c1, Complex c2)
        {
            double real = c1._real * c2._real - c1._imaginary * c2._imaginary;
            double imaginary = c1._real * c2._imaginary + c1._imaginary * c2._real;
            return new Complex(real, imaginary);
        }

        // Перегрузка оператора деления: (a + bi) / (c + di) = [(ac + bd) + (bc - ad)i] / (c² + d²)
        public static Complex operator /(Complex c1, Complex c2)
        {
            if (c2._real == 0 && c2._imaginary == 0)
                throw new DivideByZeroException("Невозможно разделить на нулевое комплексное число.");

            double denominator = c2._real * c2._real + c2._imaginary * c2._imaginary;
            double real = (c1._real * c2._real + c1._imaginary * c2._imaginary) / denominator;
            double imaginary = (c1._imaginary * c2._real - c1._real * c2._imaginary) / denominator;
            return new Complex(real, imaginary);
        }

        // Переопределение метода ToString() для удобного вывода
        public override string ToString()
        {
            if (_imaginary >= 0)
                return $"{_real} + {_imaginary}i";
            else
                return $"{_real} - {Math.Abs(_imaginary)}i";
        }

        // Переопределение Equals для сравнения двух комплексных чисел
        public override bool Equals(object obj)
        {
            if (obj is Complex other)
            {
                // Сравнение с небольшой погрешностью из-за особенностей double
                const double epsilon = 1e-10;
                return Math.Abs(_real - other._real) < epsilon &&
                       Math.Abs(_imaginary - other._imaginary) < epsilon;
            }
            return false;
        }

        // Обязательное переопределение GetHashCode при переопределении Equals
        public override int GetHashCode()
        {
            return _real.GetHashCode() ^ _imaginary.GetHashCode();
        }
    }
}