using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager appManager;

        [SetUp]
        public void SetupApplicationManagerTest()
        {
            appManager = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }

        /// <summary>
        /// Генератор случайного числа
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string GenerateRandomInteger(int max)
        {
            int l = rnd.Next() * max;
            return l.ToString();
        }

        /// <summary>
        /// Генератор дня
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomDay()
        {
            string l = Convert.ToString(rnd.Next(0, 31));
            if (l == "0")
            {
                return "-";
            }
            return l;
        }

        /// <summary>
        /// Генератор месяца
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomMonth()
        {
            var collection = new Dictionary<int, string>
            {
                { 0, "-" },
                { 1, "January" },
                { 2, "February" },
                { 3, "March" },
                { 4, "April" },
                { 5, "May" },
                { 6, "June" },
                { 7, "July" },
                { 8, "August" },
                { 9, "September" },
                { 10, "October" },
                { 11, "November" },
                { 12, "December" },
            };

            int l = rnd.Next(0, 12);
            return  collection[l];

        }

        /// <summary>
        /// Генератор года невалидного/цифры за диапозоном/валидные значения
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomYear(int max)
        {
            int chooseMeaning = rnd.Next(1, 4);
            if (chooseMeaning == 1)
            {
                return GenerateRandomString(max);
            }
            else if (chooseMeaning == 2)
            {
                int l = rnd.Next(1900, 2200);
                return l.ToString();
            }
            else
            {
                int l = rnd.Next(-999, 9999);
                return l.ToString();
            }
        }

        /// <summary>
        /// Генератор случайного мобильного телефона
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomPhoneNumber()
        {
            string number = Convert.ToInt32(rnd.Next(0, 9)) +
                "-" + Convert.ToInt32(rnd.Next(100, 999)) +
                "-" + Convert.ToInt32(rnd.Next(100, 999)) +
                "-" + Convert.ToInt32(rnd.Next(10, 99)) +
                "-" + Convert.ToInt32(rnd.Next(10, 99));
            return number;
        }
    }
}

