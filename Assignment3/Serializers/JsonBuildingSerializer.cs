using System.Text.Json;
using Assignment3.Models;

namespace Assignment3.Serializers;

public class JsonBuildingSerializer : IBuildingSerializer
{
    public string Serialize<T>(T building)
    {
        string jsonString = JsonSerializer.Serialize(building);

        return jsonString;
    }
}
