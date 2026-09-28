using System.Linq;

namespace Lesson7ADO_CarDealer_
{
    internal static class Validators
    {
        public static bool IsValidModel(string model) => !string.IsNullOrWhiteSpace(model);        

        public static bool IsValidYear(int year) => year >= 1990 && year <= 2026;        

        public static bool IsValidPrice(decimal price) => price > 0;

        public static bool IsValidBrand(CarDealerEntities context, int brandId) => context.Brands.Any(b => b.Id == brandId);        

        public static bool IsValidColor(CarDealerEntities context, int colorId) => context.Colors.Any(c => c.Id == colorId);        
    }
}