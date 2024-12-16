using Assignment3.Constants;
using Assignment3.Factories;
using Assignment3.Models;

namespace Assignment3.Commands;

public class CreateBuildingListCommand : ICommand<IEnumerable<Building>>
{
    private readonly BuildingFactory buildingFactory;

    public CreateBuildingListCommand(BuildingFactory buildingFactory)
    {
        this.buildingFactory = buildingFactory;
    }

    public IEnumerable<Building> Execute()
    {
        List<Building> buildings = new List<Building>();

        Console.WriteLine("The available buildings are:");
        Console.WriteLine(BuildingType.House);
        Console.WriteLine(BuildingType.ApartmentBuilding);
        Console.WriteLine(BuildingType.Hospital);
        Console.WriteLine(BuildingType.School);
        Console.WriteLine("For ending the creation of the list type \".\"");
        bool isListDone = false;

        while (!isListDone) {
            string? input = Console.ReadLine();

            switch (input) {
                case BuildingType.House:
                case BuildingType.ApartmentBuilding:
                case BuildingType.Hospital:
                case BuildingType.School:
                    Building building = buildingFactory.Create(input);
                    SetBuildingPropertiesCommand setBuildingPropertiesCommand = new SetBuildingPropertiesCommand(building);
                    setBuildingPropertiesCommand.Execute();
                    buildings.Add(building);
                    Console.WriteLine("Building added. Enter the next one or \".\" to finish creating the list.");
                    break;
                case ".":
                    isListDone = true;
                    break;
                default:
                    Console.WriteLine("This is not a valid building type. Please try again.");
                    continue;
            }
        }

        return buildings;
    }
}
