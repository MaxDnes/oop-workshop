using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Movie : Media
{
    public string Director { get; set; }
    public string Genres { get; set; }  
    public int ReleaseYear { get; set; }
    public string Language { get; set; }
    public int Duration { get; set; }
    
    public Movie(string title, string director, string genres, 
        int releaseYear, string language, int duration) : base(title)
    {
        Director = director;
        Genres = genres;
        ReleaseYear = releaseYear;
        Language = language;
        Duration = duration;
    }

}
