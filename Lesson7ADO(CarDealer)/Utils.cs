using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lesson7ADO_CarDealer_
{
    internal static class Utils
    {
        public static void ShowResult(IEnumerable<Cars> cars)
        {
            WriteLine($"{"Id",-5}{"Brand",-12}{"Model",-15}{"Year",-8}{"Price",-15}{"Color",-12}");
            WriteLine(new string('-', 60));

            foreach (var car in cars)
            {
                WriteLine(
                    $"{car.Id,-5}" +
                    $"{car.Brands.Name,-12}" +
                    $"{car.Model,-15}" +
                    $"{car.Year,-8}" +
                    $"{car.Price,-15:F2}" +
                    $"{car.Colors.Name,-12}");
            }
        }

        public static void ShowAvailableOptions(IEnumerable<Cars> cars)
        {
            var brands = from car in cars select car.Brands.Name;

            var models = from car in cars select car.Model;

            var years = from car in cars select car.Year;

            var colors = from car in cars select car.Colors.Name;

            var prices = from car in cars select car.Price;

            WriteLine("========== AVAILABLE ==========");
            WriteLine($"Brands: {string.Join(", ", brands.Distinct())}");
            WriteLine($"Models: {string.Join(", ", models.Distinct())}");
            WriteLine($"Years: {string.Join(", ", years.Distinct())}");
            WriteLine($"Colors: {string.Join(", ", colors.Distinct())}");

            if (prices.Any()) WriteLine($"Price: {prices.Min():F2} - {prices.Max():F2}");

            WriteLine("================================");
        }
    }
}