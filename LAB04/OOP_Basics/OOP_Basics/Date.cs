using System;

namespace DateApp
{
    public class Date
    {
        private int year;
        private int month;
        private int day;

        // Конструктор для инициализации даты
        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        // Свойство для года
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Year must be greater than or equal to 1.");
                year = value;
            }
        }

        // Свойство для месяца
        public int Month
        {
            get { return month; }
            set
            {
                if (value < 1  value > 12)
                    throw new ArgumentException("Month must be between 1 and 12.");
                month = value;
            }
        }

        // Свойство для дня
        public int Day
        {
            get { return day; }
            set
            {
                if (value < 1  value > GetDaysInMonth(Month, Year))
                    throw new ArgumentException($"Day must be between 1 and {GetDaysInMonth(Month, Year)} for the given month and year.");
                day = value;
            }
        }



        // Метод для вычисления количества дней в месяце
        private int GetDaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    // Проверка на високосный год
                    return DateTime.IsLeapYear(year) ? 29 : 28;
                default:
                    throw new ArgumentException("Invalid month.");
            }
        }


        // Метод для добавления n дней к текущей дате
        public void AddDays(int n)
        {
            DateTime currentDate = new DateTime(Year, Month, Day);
            DateTime newDate = currentDate.AddDays(n);
            Year = newDate.Year;
            Month = newDate.Month;
            Day = newDate.Day;
        }



        // Метод для добавления n дней к текущей дате с изменением месяца и года
        public Date AddDays(int n)
        {
            return new Date(year, month, day + n);
        }


        public Date AddDays(int n)
        {
            int newYear = year;
            int newMonth = month;
            int newDay = day + n;


            while (newDay > daysInMonth[newMonth - 1])
            {
                // Вычитаем дни текущего месяца
                newDay -= daysInMonth[newMonth - 1];

                // Переход к следующему месяцу
                newMonth++;

                if (newMonth > 12)
                {
                    // Переход к следующему году
                    newMonth = 1;
                    newYear++;

                    if (DateTime.IsLeapYear(newYear))
                    {
                        daysInMonth[1] = 29;
                    }
                    else
                    {
                        daysInMonth[1] = 28;
                    }
                }
            }

            return new Date(newYear, newMonth, newDay);
        }


        // Метод для вывода даты в читаемом виде
        public void PrintDate()
        {
            Console.WriteLine($"{Day:D2}.{Month:D2}.{Year}");
        }
    }
}