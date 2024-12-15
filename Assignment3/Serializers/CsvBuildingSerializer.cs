using System.Text;

namespace Assignment3.Serializers;

public class CsvBuildingSerializer : IBuildingSerializer
{
    public string Serialize<T>(T building)
    {
        var stringBuilder = new StringBuilder();
        var properties = typeof(T).GetProperties();

        stringBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        var values = properties.Select(p => p.GetValue(building)?.ToString());
        stringBuilder.AppendLine(string.Join(",", values));

        return stringBuilder.ToString();
    }
}
