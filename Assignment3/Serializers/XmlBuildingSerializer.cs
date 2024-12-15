using System.Xml.Serialization;
using Assignment3.Models;

namespace Assignment3.Serializers;

public class XmlBuildingSerializer : IBuildingSerializer
{
    public string Serialize<Building>(Building building)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Building));

        using (StringWriter stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, building);

            return stringWriter.ToString();
        }
    }
}
