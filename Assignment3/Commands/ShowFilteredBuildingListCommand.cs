using Assignment3.Models;

namespace Assignment3.Commands;

public class ShowFilteredBuildingListCommand : ICommand<string>
{
    private readonly IEnumerable<Building> buildings;

    private readonly ICommand<Type> chooseBuildingTypeCommand;

    private readonly ICommand<string> showBuildingListCommand;

    public ShowFilteredBuildingListCommand(IEnumerable<Building> buildings, ICommand<Type> chooseBuildingTypeCommand,
        ICommand<string> showBuildingListCommand)
    {
        this.buildings = buildings;
        this.chooseBuildingTypeCommand = chooseBuildingTypeCommand;
        this.showBuildingListCommand = showBuildingListCommand;
    }

    public string Execute()
    {
        Type buildingType = chooseBuildingTypeCommand.Execute();

        List<Building> filteredBuildings = new List<Building>();

        foreach (Building building in buildings)
        {
            if (building.GetType() == buildingType)
            {
                filteredBuildings.Add(building);
            }
        }

        if (filteredBuildings.Count() == 0)
        {
            Console.WriteLine("There are no such buildings in the list.");

            return string.Empty;
        }

        string serializedBuildings = showBuildingListCommand.Execute();

        return serializedBuildings;
    }
}
