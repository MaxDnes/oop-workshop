using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Pdcast : Media, IPodcast
{
    private int EpisodNumber { get; set; }
    private string Host { get; set; }
    private string Guest { get; set; }
    private int ReleaseYear { get; set; }
    public Pdcast(string title, int episodNumber, string host, string guest,
        int releaseYear)
        : base(title)
    {
       EpisodNumber = episodNumber;
       Host = host;
       Guest = guest;
       ReleaseYear = releaseYear;
    }
   public void Listen()
    {
        throw new NotImplementedException();
    }
    public void Complete()
    {
        throw new NotImplementedException();
    }
}