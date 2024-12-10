namespace Assignment3.Models;

public class ApartmentBuilding : Building
{
    public byte NumberOfLevels { get; set; }

    public byte NumberOfApartments { get; set; }

    public ApartmentBuilding(string address) : base(address) {}

    public ApartmentBuilding(string address, byte numberOfLevels, byte numberOfApartments) : base(address)
    {
        NumberOfLevels = numberOfLevels;
        NumberOfApartments = numberOfApartments;
    }

    public override void Print()
    {

    }
}
