using static System.Console;

namespace Lesson7ADO_CarDealer_
{
    internal static class UI
    {
        public static void ShowMainMenu(CarDealerEntities context)
        {
            while (true)
            {
                Clear();

                WriteLine("========== CAR DEALER ==========");
                WriteLine("1. Show all cars");
                WriteLine("2. Search by parameter");
                WriteLine("3. Add car");
                WriteLine("4. Edit car");
                WriteLine("5. Delete car");
                WriteLine("0. Exit");
                WriteLine("===============================");

                Write("Choice: ");

                if (!int.TryParse(ReadLine(), out int choice))
                {
                    WriteLine("Invalid input. Please enter a number! Press any key to continue...");
                    ReadKey();
                    continue;
                }

                if (choice == 0) return;

                switch (choice)
                {
                    case 1: Handler.ShowAllCars(context); break;
                    case 2: Handler.Search(context); break;
                    case 3: Handler.AddCar(context); break;
                    case 4: Handler.EditCar(context); break;
                    case 5: Handler.DeleteCar(context); break;                    
                }

                WriteLine("Press any key to continue...");
                ReadKey();
            }
        }        
    }
}        