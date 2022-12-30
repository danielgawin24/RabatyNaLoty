using System;
using System.Windows;

namespace RabatyNaLoty
{
    class RabatyNaLoty
    {
        public static void Main(string[] args)
        {
            bool isInternational;
            bool isRegular = false;
            bool isInSeason = true;

            int totalDiscount = 0;

            Console.WriteLine("Witaj w centrum linii lotniczych WSEI Kraków!\n");

            Console.Write("Jak masz na imię: ");
            string userName = Console.ReadLine();
            if (userName == null)
                throw new ArgumentNullException("Aby podróżować należy podać prawdziwe imię!");

            Console.Write("Kiedy się urodziłeś? (format MM/DD/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            DateTime actualTime = DateTime.Now;
            
            int userAge = actualTime.Year - birthDate.Year;
            if (birthDate > DateTime.Now)
                throw new ArgumentException("Musisz się urodzić aby podróżować samolotem!");
            if (userAge < 0)
                throw new ArgumentException("Wiek nie może być ujemny!");

            Console.Write("Kiedy odbędzie się wylot? (format MM/DD/YYYY): ");
            DateTime flightDate = DateTime.Parse(Console.ReadLine());

            int monthDiff = ((flightDate.Year - actualTime.Year)*12)+(flightDate.Month - actualTime.Month);
            int flightYear = flightDate.Year;

            Console.Write("Czy lot będzie krajowy czy międzynarodowy? ");
            string isInternationalInput = Console.ReadLine().Trim().ToLower();
            if (isInternationalInput.Equals("międzynarodowy") || isInternationalInput.Equals("miedzynarodowy"))
            {
                isInternational = true;
            }
            else if (isInternationalInput.Equals("krajowy"))
            {
                isInternational = false;
            }
            else
                throw new ArgumentException("Lot może być tylko krajowy lub międzynarodowy");

            if (userAge >= 18)
            {
                Console.Write("Czy jesteś klientem stałym? ");
                string isRegularInput = Console.ReadLine().Trim().ToLower();
                if (isRegularInput.Equals("tak"))
                {
                    isRegular = true;
                }
                else if (isRegularInput.Equals("nie"))
                {
                    isRegular = false;
                }
            }

            DateTime winterStart = new DateTime((flightYear - 1), 12, 20);
            DateTime winterEnd = new DateTime(flightYear, 01, 10);

            DateTime easterStart = new DateTime(flightYear, 03, 20);
            DateTime easterEnd = new DateTime(flightYear, 04, 10);

            if (winterStart <= flightDate && flightDate <= winterEnd)
            {
                isInSeason = true;
            }
            else if (easterStart <= flightDate && flightDate <= easterEnd)
            {
                isInSeason = true;
            }
            else if (flightDate.Month == 7 || flightDate.Month == 8)
            {
                isInSeason = true;
            }
            else
            {
                isInSeason = false;
            }

            if (userAge < 2 && isInternational == true)
            {
                totalDiscount += 70;
            }
            else if (userAge < 2 && isInternational == false)
            {
                totalDiscount += 80;
            }

            if (2 < userAge && userAge < 16)
            {
                totalDiscount += 10;
            }
            if (monthDiff > 5)
            {
                totalDiscount += 10;
            }
            if (isInternational == true && isInSeason == false)
            {
                totalDiscount += 15;
            }
            if (userAge > 18 && isRegular == true)
            {
                totalDiscount += 15;
            }
            if (userAge < 2 && totalDiscount > 80)
            {
                totalDiscount = 80;
            }
            if (userAge > 2 && totalDiscount > 30)
            {
                totalDiscount = 30;
            }
            Console.WriteLine("");

            Console.WriteLine(userAge);
            Console.WriteLine(isInternational);
            Console.WriteLine(isInSeason);

            if (userName.EndsWith("a") || userName.EndsWith("A"))
            {
                Console.WriteLine($"Pani ostateczny, całkowity rabat wynosi: {totalDiscount}%");
            }
            else
            {
                Console.WriteLine($"Pana ostateczny, całkowity rabat wynosi: {totalDiscount}%");
            }
        }
    }
}