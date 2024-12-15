using System.Text;
using Assignment3.Factories;
using Assignment3.Models;
using Assignment3.Serializers;

namespace Assignment3.Commands;

public class ShowBuildingListCommand : ICommand<string>
{
    private readonly IEnumerable<Building> buildings;

    private readonly ICommand<string> chooseFormatCommand;

    public ShowBuildingListCommand(IEnumerable<Building> buildings, ICommand<string> chooseFormatCommand)
    {
        this.buildings = buildings;
        this.chooseFormatCommand = chooseFormatCommand;
    }

    public string Execute()
    {
        string format = chooseFormatCommand.Execute();

        IBuildingSerializer buildingSerializer = new BuildingSerializerFactory().Create(format);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (Building building in buildings) {
            stringBuilder.Append(buildingSerializer.Serialize(building));
        }

        string serializedBuildings = stringBuilder.ToString();

        Console.WriteLine(serializedBuildings);

        return serializedBuildings;
    }
}
