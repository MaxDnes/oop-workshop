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
    
    // virtual to be able to override
    public virtual void Download()
    {
        Console.WriteLine($"{Title} is downloading...");
    }
    
    // TODO: uncomment after implemented user logic
    /*public virtual void Rate(Borrower user, int score)
    {
        if (Ratings.ContainsKey(user))
            Ratings[user] = score;
        else
            Ratings.Add(user, score);
        Console.WriteLine($"{user.Name} rated {Title} with {score} points.");
    }*/
}
