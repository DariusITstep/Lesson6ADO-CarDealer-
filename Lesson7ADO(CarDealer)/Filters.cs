using System.Collections.Generic;
using System.Linq;

namespace Lesson7ADO_CarDealer_
{
    internal class Filters
    {
        public static IEnumerable<Cars> FilterByBrand(IEnumerable<Cars> cars, string brand) =>        
        cars.Where(c => c.Brands.Name == brand);        

        public static IEnumerable<Cars> FilterByModel(IEnumerable<Cars> cars, string model) =>        
        cars.Where(c => c.Model == model);        

        public static IEnumerable<Cars> FilterByColor(IEnumerable<Cars> cars, string color) =>        
        cars.Where(c => c.Colors.Name == color);        

        public static IEnumerable<Cars> FilterByYear(IEnumerable<Cars> cars, int year) =>
        cars.Where(c => c.Year == year);

        public static IEnumerable<Cars> FilterByPriceRange(IEnumerable<Cars> cars, decimal minPrice, decimal maxPrice) =>        
        cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice);        
    }
}