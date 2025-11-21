using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Podcast : Media, IListenable
{
    public int ReleaseYear { get; set; }
    public string Hosts { get; set; }
    public string Guests { get; set; }
    public int EpisodeNumber { get; set; }
    public string Language { get; set; }
    
    public Podcast(string title, int releaseYear, string hosts, 
        string guests, int episodeNumber, string language) : base(title)
    {
        ReleaseYear = releaseYear;
        Hosts = hosts;
        Guests = guests;
        EpisodeNumber = episodeNumber;
        Language = language;
    }


    public void Listen()
    {
        throw new NotImplementedException();
    }
}
