using Assignment3.Models;

namespace Assignment3.Factories;

public class BuildingFactory
{
    public Building Create(string buildingType, string address = "")
    {
        switch (buildingType) {
            case BuildingType.House:
                return new House(address);
            case BuildingType.ApartmentBuilding:
                return new ApartmentBuilding(address);
            case BuildingType.Hospital:
                return new Hospital(address);
            default:
                return new School(address);
        }
    }
}
