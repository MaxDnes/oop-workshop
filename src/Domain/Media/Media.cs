namespace oop.Domain.Media;

public abstract class Media
{
    public string Title { get; set; }
    public bool IsBorrowed { get; set; }
    
    // TODO: change from string to Rating after implemented 
    public Dictionary<string, int> Ratings { get; set; } 

    protected Media(string title)
    {
        Title = title;
    }

    public void Borrow() => IsBorrowed = true;
    public void Return() => IsBorrowed = false;

    public double GetAverageRating()
    {
        return Ratings.Values.Average();
    }
}
