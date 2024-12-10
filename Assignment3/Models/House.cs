namespace Assignment3.Models;

public class House : Building
{
    public string? Owner { get; set; }

    public float Area { get; set; }

    public House(string address) : base(address) {}

    public House(string owner, string address, float area) : base(address)
    {
        Owner = owner;
        Area = area;
    }

    public void Print()
    {
        
    }
}
