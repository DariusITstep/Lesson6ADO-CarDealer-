using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace Lesson7ADO_CarDealer_
{
    internal static class Handler
    {
        public static void ShowAllCars(CarDealerEntities context)
        {
            Clear();
            Utils.ShowResult(context.Cars);
        }

        public static void Search(CarDealerEntities context)
        {
            IEnumerable<Cars> result = context.Cars;

            while (true)
            {
                Clear();
                Utils.ShowAvailableOptions(result);

                WriteLine();
                WriteLine("1. Brand");
                WriteLine("2. Model");
                WriteLine("3. Year");
                WriteLine("4. Price");
                WriteLine("5. Color");
                WriteLine("6. Show result");
                WriteLine("0. Back");

                Write("Choice: ");

                if (!int.TryParse(ReadLine(), out int choice)) continue;
                if (choice == 0) return;

                switch (choice)
                {
                    case 1:
                        Write("Enter brand: ");
                        result = Filters.FilterByBrand(result, ReadLine());
                        break;

                    case 2:
                        Write("Enter model: ");
                        result = Filters.FilterByModel(result, ReadLine());
                        break;

                    case 3:
                        Write("Enter year: ");

                        if (int.TryParse(ReadLine(), out int year)) result = Filters.FilterByYear(result, year);
                        break;

                    case 4:
                        Write("Enter min price: ");

                        if (decimal.TryParse(ReadLine(), out decimal minPrice))
                        {
                            Write("Enter max price: ");

                            if (decimal.TryParse(ReadLine(), out decimal maxPrice))
                            result = Filters.FilterByPriceRange(result, minPrice, maxPrice);
                        }
                        break;

                    case 5:
                        Write("Enter color: ");
                        result = Filters.FilterByColor(result, ReadLine());
                        break;

                    case 6:
                        Clear();
                        Utils.ShowResult(result);
                        WriteLine();
                        WriteLine("Press any key to continue...");
                        ReadKey();
                        break;
                }
            }
        }

        public static void AddCar(CarDealerEntities context)
        {
            Clear();

            WriteLine("========== ADD CAR ==========");

            Write("Model: ");
            string model = ReadLine();

            if (!Validators.IsValidModel(model))
            {
                WriteLine("Invalid model!");
                ReadKey();
                return;
            }

            Write("Year: ");

            if (!int.TryParse(ReadLine(), out int year) ||
                !Validators.IsValidYear(year))
            {
                WriteLine("Invalid year!");
                ReadKey();
                return;
            }

            Write("Price: ");

            if (!decimal.TryParse(ReadLine(), out decimal price) || !Validators.IsValidPrice(price))
            {
                WriteLine("Invalid price!");
                ReadKey();
                return;
            }

            WriteLine("Available brands:");
            for (int i = 0; i < context.Brands.Count(); i++)
            {
                var brand = context.Brands.OrderBy(b => b.Id).ToList()[i];
                WriteLine($"{brand.Id} - {brand.Name}");
            }

            Write("Brand ID: ");

            if (!int.TryParse(ReadLine(), out int brandId) || !Validators.IsValidBrand(context, brandId))
            {
                WriteLine("Invalid brand!");
                ReadKey();
                return;
            }

            WriteLine("Available colors:");
            for (int i = 0; i < context.Colors.Count(); i++)
            {
                var color = context.Colors.OrderBy(c => c.Id).ToList()[i];
                WriteLine($"{color.Id} - {color.Name}");
            }

            Write("Color ID: ");

            if (!int.TryParse(ReadLine(), out int colorId) ||
                !Validators.IsValidColor(context, colorId))
            {
                WriteLine("Invalid color.");
                ReadKey();
                return;
            }

            Cars car = new Cars
            {
                Model = model,
                Year = year,
                Price = price,
                BrandId = brandId,
                ColorId = colorId
            };

            context.Cars.Add(car);
            context.SaveChanges();

            WriteLine();
            WriteLine("Car added successfully!");
            ReadKey();
        }

        public static void EditCar(CarDealerEntities context)
        {
            Clear();

            WriteLine("========== EDIT CAR ==========");

            Write("Enter car ID: ");

            if (!int.TryParse(ReadLine(), out int id))
            {
                WriteLine("Invalid ID.");
                ReadKey();
                return;
            }

            Cars car = context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                WriteLine("Car not found.");
                ReadKey();
                return;
            }

            WriteLine($"Editing car: {car.Model} ({car.Year}) - ${car.Price}");

            Write("Model: ");
            string model = ReadLine();

            if (!Validators.IsValidModel(model))
            {
                WriteLine("Invalid model.");
                ReadKey();
                return;
            }

            Write("Year: ");

            if (!int.TryParse(ReadLine(), out int year) || !Validators.IsValidYear(year))
            {
                WriteLine("Invalid year.");
                ReadKey();
                return;
            }

            Write("Price: ");

            if (!decimal.TryParse(ReadLine(), out decimal price) || !Validators.IsValidPrice(price))
            {
                WriteLine("Invalid price.");
                ReadKey();
                return;
            }

            WriteLine("Available brands:");
            for (int i = 0; i < context.Brands.Count(); i++)
            {
                var brand = context.Brands.OrderBy(b => b.Id).ToList()[i];
                WriteLine($"{brand.Id} - {brand.Name}");
            }

            Write("Brand ID: ");

            if (!int.TryParse(ReadLine(), out int brandId) || !Validators.IsValidBrand(context, brandId))
            {
                WriteLine("Invalid brand.");
                ReadKey();
                return;
            }

            Write("Color ID: ");

            WriteLine("Available colors:");
            for (int i = 0; i < context.Colors.Count(); i++)
            {
                var color = context.Colors.OrderBy(c => c.Id).ToList()[i];
                WriteLine($"{color.Id} - {color.Name}");
            }

            if (!int.TryParse(ReadLine(), out int colorId) || !Validators.IsValidColor(context, colorId))
            {
                WriteLine("Invalid color.");
                ReadKey();
                return;
            }

            car.Model = model;
            car.Year = year;
            car.Price = price;
            car.BrandId = brandId;
            car.ColorId = colorId;

            context.SaveChanges();

            WriteLine();
            WriteLine("Car updated successfully.");
            ReadKey();
        }

        public static void DeleteCar(CarDealerEntities context)
        {
            Clear();

            Write("Enter car ID: ");

            if (!int.TryParse(ReadLine(), out int id))
            {
                WriteLine("Invalid ID.");
                ReadKey();
                return;
            }

            Cars car = context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                WriteLine("Car not found.");
                ReadKey();
                return;
            }

            context.Cars.Remove(car);
            context.SaveChanges();

            WriteLine("Car deleted successfully.");
            ReadKey();
        }
    }
}