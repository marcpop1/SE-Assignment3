using System.Xml.Serialization;

namespace Assignment3.Models;

[XmlInclude(typeof(House))]
public class House : Building
{
    public string? Owner { get; set; }

    public float Area { get; set; }

    public House() { }

    public House(string address) : base(address) { }

    public House(string owner, string address, float area) : base(address)
    {
        Owner = owner;
        Area = area;
    }

    public override void Print()
    {

    }
}
