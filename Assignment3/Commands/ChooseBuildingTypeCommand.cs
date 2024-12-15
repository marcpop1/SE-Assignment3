using Assignment3.Models;

namespace Assignment3.Commands;

public class ChooseBuildingTypeCommand : ICommand<Type>
{
    public Type Execute()
    {
        Console.WriteLine("Available building types:");
        Console.WriteLine(BuildingType.House);
        Console.WriteLine(BuildingType.ApartmentBuilding);
        Console.WriteLine(BuildingType.Hospital);
        Console.WriteLine(BuildingType.School);

        while (true)
        {
            string? input = Console.ReadLine();

            switch (input)
            {
                case BuildingType.House:
                    return typeof(House);
                case BuildingType.ApartmentBuilding:
                    return typeof(ApartmentBuilding);
                case BuildingType.Hospital:
                    return typeof(Hospital);
                case BuildingType.School:
                    return typeof(School);
                default:
                    Console.WriteLine("There is no such building type. Please try again.");
                    continue;
            }
        }
    }
}
