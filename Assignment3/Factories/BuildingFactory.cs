using Assignment3.Constants;
using Assignment3.Models;

namespace Assignment3.Factories;

public class BuildingFactory
{
    public Building Create(string buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.House:
                return new House();
            case BuildingType.ApartmentBuilding:
                return new ApartmentBuilding();
            case BuildingType.Hospital:
                return new Hospital();
            default:
                return new School();
        }
    }
}
