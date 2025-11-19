using oop.Domain.Interfaces;

namespace oop.Domain.Media
{
    public class Song : Media, IPlayable
    {
        private string Artist { get; set; }
        private string Album { get; set; }
        private int ReleaseYear { get; set; }
        private string Genre { get; set; }

        public Song(string title, string artist, string album, int releaseYear, string genre)
            : base(title)
        {
            Artist = artist;
            Album = album;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} by {Artist}...");
        }
    }
}
