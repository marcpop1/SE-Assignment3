using System.Xml.Serialization;

namespace Assignment3.Serializers;

public class XmlBuildingSerializer : IBuildingSerializer
{
    public string Serialize<Building>(Building building)
    {
        XmlSerializer serializer = new XmlSerializer(building.GetType());

        using (StringWriter stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, building);

            return stringWriter.ToString();
        }
    }
}
