using Assignment3.Models;

namespace Assignment3.Commands;

public class ShowFilteredBuildingListCommand : ICommand<string>
{
    private readonly IEnumerable<Building> buildings;

    private readonly ICommand<Type> chooseBuildingTypeCommand;

    public ShowFilteredBuildingListCommand(IEnumerable<Building> buildings, ICommand<Type> chooseBuildingTypeCommand)
    {
        this.buildings = buildings;
        this.chooseBuildingTypeCommand = chooseBuildingTypeCommand;
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

        ICommand<string> showBuildingListCommand = new ShowBuildingListCommand(filteredBuildings, new ChooseFormatCommand());
        string serializedBuildings = showBuildingListCommand.Execute();

        return serializedBuildings;
    }
}
