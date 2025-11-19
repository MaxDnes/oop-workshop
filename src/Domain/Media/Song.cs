using oop.Domain.Interfaces;
using System;

namespace oop.Domain.Media
{
    public class Song : Media, IPlayable
    {
        public string Artist { get; private set; }
        public string Album { get; private set; }
        public int ReleaseYear { get; private set; }
        public string Genre { get; private set; }

        public Song(string title, string artist, string album, int releaseYear, string genre)  : base(title)
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