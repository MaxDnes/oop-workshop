namespace oop.Domain.User;

public abstract class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string SSN { get; set; }  // Social Security Number

    protected User(string name, int age, string ssn)
    {
        Name = name;
        Age = age;
        SSN = ssn;
    }

    public abstract void DisplayRole();
        
    public override string ToString()
    {
        return $"{Name} (Age: {Age}, SSN: {SSN})";
    }
}