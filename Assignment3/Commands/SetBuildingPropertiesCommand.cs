using System.Globalization;
using System.Reflection;
using Assignment3.Models;

namespace Assignment3.Commands;

public class SetBuildingPropertiesCommand : ICommand<Building>
{
    private readonly Building building;

    public SetBuildingPropertiesCommand(Building building)
    {
        this.building = building;
    }

    public Building Execute()
    {
        Console.WriteLine("Set details:");
        var properties = building.GetType().GetProperties();

        foreach (PropertyInfo property in properties)
        {
            while (true)
            {
                Console.WriteLine(property.Name + ":");

                if (property.PropertyType == typeof(List<string>))
                {
                    Console.WriteLine("Enter each value on a separate line and then press enter.");

                    List<string> valueList = new List<string>();

                    while (true)
                    {
                        string? listInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(listInput))
                        {
                            break;
                        }

                        valueList.Add(listInput);
                    }

                    property.SetValue(building, valueList);
                    break;
                }

                string? input = Console.ReadLine();

                if (input == null)
                {
                    input = "";
                }

                object convertedInput = ConvertInput(input, property.PropertyType);

                if (convertedInput != null)
                {
                    property.SetValue(building, convertedInput);
                    break;
                }

                Console.WriteLine("Incorrect format. Please try again.");
            }
        }

        return building;
    }

    private object ConvertInput(string input, Type targetType)
    {
        try
        {
            if (targetType == typeof(int))
                return int.Parse(input, CultureInfo.InvariantCulture);
            if (targetType == typeof(float))
            {
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatResult))
                    return floatResult;

                if (int.TryParse(input, CultureInfo.InvariantCulture, out int intAsFloat))
                    return (float)intAsFloat;
            }
            if (targetType == typeof(double))
            {
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleResult))
                    return doubleResult;

                if (int.TryParse(input, CultureInfo.InvariantCulture, out int intAsDouble))
                    return (double)intAsDouble;
            }
            if (targetType == typeof(bool))
                return bool.Parse(input);
            if (targetType == typeof(DateTime))
                return DateTime.Parse(input);
            if (targetType == typeof(byte))
                return byte.Parse(input, CultureInfo.InvariantCulture);
            if (targetType == typeof(string))
                return input;

            return Convert.ChangeType(input, targetType);
        }
        catch
        {
            return null;
        }
    }
}
