using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Song : Media
{
    public string Composer { get; set; }
    public string Singer { get; set; }
    public string Genre { get; set; }
    public string FileType { get; set; }
    public int Duration { get; set; }
    public string Language { get; set; }
    
    public Song(string title, string composer, string singer, string genre, 
        string fileType, int duration, string language) : base(title)
    {
        Composer = composer;
        Singer = singer;
        Genre = genre;
        FileType = fileType;
        Duration = duration;
        Language = language;
    }
    
}