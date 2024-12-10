namespace Assignment3.Models;

public class School : Building
{
    public string? Name { get; set; }

    public byte NumberOfClasses { get; set; }

    public School(string address) : base(address) {}

    public School(string name, string address, byte numberOfClasses) : base (address)
    {
        Name = name;
        NumberOfClasses = numberOfClasses;
    }

    public void Print()
    {

    }
}
