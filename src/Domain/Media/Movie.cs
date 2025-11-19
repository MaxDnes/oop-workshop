using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Movie : Media, IWatchable
{
    private string Director {  get; set; }
    private string Genre    { get; set; }
    private int ReleaseYear { get; set; }
    private int Duration { get; set; }
    public string Language { get; set; }
    
    public Movie(string title, string language, string director, string genre, int releaseYear, int duration) : base(title)   
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