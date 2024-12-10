using Assignment3.Models;

namespace Assignment3;

public class BuildingFactory
{
    public Building Create(BuildingType buildingType, string address)
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
