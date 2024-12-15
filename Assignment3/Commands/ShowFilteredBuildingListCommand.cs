using Assignment3.Models;

namespace Assignment3.Commands;

public class ShowFilteredBuildingListCommand : ICommand<string>
{
    private readonly IEnumerable<Building> buildings;

    public ShowFilteredBuildingListCommand(IEnumerable<Building> buildings)
    {
        this.buildings = buildings;
    }

    public string Execute()
    {
        ICommand<Type> chooseBuildingTypeCommand = new ChooseBuildingTypeCommand();

        Type buildingType = chooseBuildingTypeCommand.Execute();

        List<Building> filteredBuildings = new List<Building>();

        foreach (Building building in buildings)
        {
            if (building.GetType() == buildingType)
            {
                filteredBuildings.Add(building);
            }
        }

        ICommand<string> showBuildingListCommand = new ShowBuildingListCommand(filteredBuildings, new ChooseFormatCommand());

        string serializedBuildings = showBuildingListCommand.Execute();

        return serializedBuildings;
    }
}
