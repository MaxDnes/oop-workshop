using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Song : Media, IPlayable
{
    private string Composer;
    private string Singer;
    private string Genre;
    private string FileType;
    public int Duration;

    public Movie(string title, string composer, string singer, string genre,
        string fileType, int duration)
        : base(title)   
    {
        Composer = composer;
        Singer = singer;    
        Genre = genre;
        FileType = fileType;
        Duration = duration;
    }

    void Play()
    {
        throw new NotImplementedException();
    }

}