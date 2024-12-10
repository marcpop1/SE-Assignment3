using Assignment3;
using Assignment3.Models;

Console.WriteLine("Hello, World!");

BuildingFactory factory = new BuildingFactory();

Building house = factory.Create(BuildingType.House, "New Address");

Console.WriteLine(house.Address);