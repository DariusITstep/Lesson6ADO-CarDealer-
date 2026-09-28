using System.Collections.Generic;

namespace Lesson7ADO_CarDealer_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CarDealerEntities())
            {
                UI.ShowMainMenu(context);
            }
        }
    }
}

//CREATE DATABASE CarDealer;
//GO

//USE CarDealer;
//GO

//CREATE TABLE Brands
//(
//    Id INT PRIMARY KEY IDENTITY,
//    Name NVARCHAR(50) UNIQUE NOT NULL
//);

//CREATE TABLE Colors
//(
//    Id INT PRIMARY KEY IDENTITY,
//    Name NVARCHAR(30) UNIQUE NOT NULL
//);

//CREATE TABLE Cars
//(
//    Id INT PRIMARY KEY IDENTITY,
//    [Model] NVARCHAR(50) NOT NULL,
//    [Year] INT NOT NULL CHECK([Year] BETWEEN 1990 AND 2026),
//    Price MONEY NOT NULL CHECK(Price>0),

//    BrandId INT NOT NULL,
//    ColorId INT NOT NULL,

//    FOREIGN KEY (BrandId) REFERENCES Brands(Id),
//    FOREIGN KEY (ColorId) REFERENCES Colors(Id)
//);

//INSERT INTO Brands VALUES
//('Toyota'),
//('BMW'),
//('Audi'),
//('Ford');

//INSERT INTO Colors VALUES
//('Black'),
//('White'),
//('Red'),
//('Blue');

//INSERT INTO Cars VALUES
//('Camry',2022,1200000,1,1),
//('Corolla', 2021, 850000, 1, 2),
//('X5', 2023, 2900000, 2, 1),
//('A4', 2020, 1400000, 3, 4),
//('Focus', 2019, 600000, 4, 3);