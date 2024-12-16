using Assignment3.Commands;
using Assignment3.Factories;
using Assignment3.Models;

IEnumerable<Building> buildings = new List<Building>();

while (true)
{
    Console.WriteLine("Available commands:");
    Console.WriteLine("create-list: Create a new building list.");

    if (buildings.Count() != 0)
    {
        Console.WriteLine("show-list: Show the created building list in XML / JSON / CSV format.");
        Console.WriteLine("show-filtered-list: Show the created building list in XML / JSON / CSV format filtered by building type.");
    }

    string? input = Console.ReadLine();

    switch (input)
    {
        case "create-list":
            BuildingFactory factory = new BuildingFactory();
            CreateBuildingListCommand createBuildingListCommand = new CreateBuildingListCommand(factory);
            buildings = createBuildingListCommand.Execute();
            break;
        case "show-list":
            ChooseFormatCommand chooseFormatCommand = new ChooseFormatCommand();
            ShowBuildingListCommand showBuildingListCommand = new ShowBuildingListCommand(buildings, chooseFormatCommand);
            showBuildingListCommand.Execute();
            break;
        case "show-filtered-list":
            ChooseBuildingTypeCommand chooseBuildingTypeCommand = new ChooseBuildingTypeCommand();
            ChooseFormatCommand chooseFormatCommandForFiltered = new ChooseFormatCommand();
            ShowBuildingListCommand showBuildingListCommandForFiltered = new ShowBuildingListCommand(buildings, chooseFormatCommandForFiltered);
            ShowFilteredBuildingListCommand showFilteredBuildingListCommand = new ShowFilteredBuildingListCommand(buildings, chooseBuildingTypeCommand, showBuildingListCommandForFiltered);
            showFilteredBuildingListCommand.Execute();
            break;
        default:
            break;
    }
}