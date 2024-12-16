using System.Text;

namespace Assignment3.Serializers;

public class CsvBuildingSerializer : IBuildingSerializer
{
    public string Serialize<T>(T building)
    {
        var stringBuilder = new StringBuilder();
        var properties = building.GetType().GetProperties();

        stringBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        var values = properties.Select(p => 
        {
            var value = p.GetValue(building);
            if (value is List<string> list)
            {
                // Join List<string> items into a single string with commas (or semicolons)
                return string.Join(";", list); // You can adjust the delimiter if needed
            }
            return value?.ToString(); // For non-List<string> properties
        });
        
        stringBuilder.AppendLine(string.Join(",", values));

        return stringBuilder.ToString();
    }
}
