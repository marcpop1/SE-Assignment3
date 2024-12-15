namespace Assignment3.Serializers;

public interface IBuildingSerializer
{
    string Serialize<T>(T building);
}
