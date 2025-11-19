using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Movie : Media, IWatchable
{
    private string Director;
    private string Genre;
    private int ReleaseYear;
    private int Duration;
    public string Language;
    
    public Movie(string title, string language, string director, string genre,
        int releaseYear, int duration)
        : base(title)   // calls the Media constructor
    {
        Director = director;
        Genre = genre;
        ReleaseYear = releaseYear;
        Duration = duration;
        Language = language;
    }


    public void Watch()
    {
        throw new NotImplementedException();
    }
}