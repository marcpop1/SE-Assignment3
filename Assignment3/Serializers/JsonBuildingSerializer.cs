using System.Text.Json;

namespace Assignment3.Serializers;

public class JsonBuildingSerializer : IBuildingSerializer
{
    public string Serialize<T>(T building)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize<T>(building, options);

        return jsonString;
    }
}
