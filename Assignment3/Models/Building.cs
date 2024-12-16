using System.Text.Json.Serialization;

namespace Assignment3.Models;

[JsonDerivedType(typeof(House))]
[JsonDerivedType(typeof(ApartmentBuilding))]
[JsonDerivedType(typeof(Hospital))]
[JsonDerivedType(typeof(School))]
public abstract class Building
{
    public string? Address { get; set; }

    public Building() { }

    public Building(string address)
    {
        Address = address;
    }

    public abstract void Print();
}
