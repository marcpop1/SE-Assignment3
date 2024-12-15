namespace Assignment3.Models;

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
