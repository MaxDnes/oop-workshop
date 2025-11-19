using oop.Domain.Interfaces;

namespace oop.Domain.Media
{
    public class VideoGame : Media, IPlayable
    {
        private string Artist { get; set; }
        private string Album { get; set; }
        private int ReleaseYear { get; set; }
        private string Genre;

        public VideoGame(string title, string artist, string album, int releaseYear, string genre)
            : base(title)
        {
            Artist = artist;
            Album = album;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} by {Artist}");
        }
        public void complete()
        {
            Console.WriteLine($"You have completed the game: {Title}");
        }
    }
}
