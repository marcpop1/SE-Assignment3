using Assignment3.Constants;
using Assignment3.Serializers;

namespace Assignment3.Factories;

public class BuildingSerializerFactory
{
    public IBuildingSerializer Create(string format)
    {
        IBuildingSerializer serializer;

        switch (format)
        {
            case PrintFormat.Xml:
                serializer = new XmlBuildingSerializer();
                break;
            case PrintFormat.Json:
                serializer = new JsonBuildingSerializer();
                break;
            default:
                serializer = new CsvBuildingSerializer();
                break;
        }

        return serializer;
    }
}
