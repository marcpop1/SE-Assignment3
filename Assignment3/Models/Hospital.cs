namespace Assignment3.Models;

public class Hospital : Building
{
    public string? Name { get; set; }

    public List<string>? Departments { get; set; }

    public Hospital(string address) : base(address) {}

    public Hospital(string name, string address, List<string> departments) : base(address)
    {
        Name = name;
        Departments = departments;
    }

    public void Print()
    {

    }
}
