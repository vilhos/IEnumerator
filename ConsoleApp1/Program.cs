using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Day day = new Day();
            Date date = new Date();
            Week week = new Week(date,day);

            foreach (int num1 in date)
            {
                Console.WriteLine(num1);
            }

            foreach (string num2 in day)
            {
                Console.WriteLine(num2);
            }

            foreach (KeyValuePair<Date, Day> keyValue in week)
            {
                foreach (var key in keyValue.Key)
                {
                    foreach (var value in keyValue.Value)
                    {
                        Console.WriteLine($"{ key} {value}");
                    }
                }
            }
            Console.ReadLine();
        }
    }

    class Day
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator()
        {
            return new DayEnumerator(days);
        }
    }

    class DayEnumerator : IEnumerator
    {
        string[] _days;
        int position = -1;
        public DayEnumerator(string[] days)
        {
            _days = days;
        }
        public object Current => _days[position];

        public bool MoveNext()
        {
            if (position < _days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }

    class Date : IEnumerable
    {
        int[] date = {1,2,3,4,5,6,7};

        public IEnumerator GetEnumerator()
        {
            return new DateEnumerator(date);
        }
    }

    class DateEnumerator : IEnumerator
    {
        int[] _date;
        int position = -1;
        public DateEnumerator(int[] date)
        {
            _date = date;
        }
        public object Current => _date[position];

        public bool MoveNext()
        {
            if (position < _date.Length-1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class Week
    {
        Dictionary<Date, Day> week = new Dictionary<Date, Day>();

        public Week(Date date, Day day)
        {
            week.Add(date, day);
        }
        public IEnumerator GetEnumerator()
        {
            return week.GetEnumerator();
        }
    }
}
