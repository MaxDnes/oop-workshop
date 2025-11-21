using oop.Domain.Interfaces;

namespace oop.Domain.Media
{
    public class VideoGame : Media, IPlayable
    {
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int ReleaseYear { get; set; }
        public string SupportedPlatforms { get; set; }

        public VideoGame(string title, string publisher, int releaseYear, string genre, string supportedPlatforms)
            : base(title)
        {
            Genre = genre;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            SupportedPlatforms = supportedPlatforms;
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} by {Publisher}...");
        }
    }
}
