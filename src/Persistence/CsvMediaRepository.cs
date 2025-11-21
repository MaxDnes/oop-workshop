namespace oop.Persistence
{
    public class CsvMediaRepository
    {
        private readonly string _filePath;
        
        public CsvMediaRepository(string filePath = "var/media.csv")
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "Type,Title,Author,Language,Pages,Year,ISBN,Director,Genres,Duration,Composer,Singer,FileType,Genre,Publisher,Platforms,Version,FileSize,Resolution,FileFormat,DateTaken,Hosts,Guests,EpisodeNumber,ReleaseYear,Ratings\n");
            }
        }

        public List<Domain.Media.Media> LoadAll()
        {
            var Medias = new List<Domain.Media.Media>();
            
            try
            {
                var lines = File.ReadAllLines(_filePath);
                
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    
                    try
                    {
                        var media = ParseMediaLine(lines[i]);
                        if (media != null)
                        {
                            Medias.Add(media);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing line {i}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading media: {ex.Message}");
            }
            
            return Medias;
        }

        private Domain.Media.Media ParseMediaLine(string line)
        {
            var parts = SplitCsvLine(line);
            if (parts.Length < 26) 
            {
                // Pad array if needed
                Array.Resize(ref parts, 26);
            }
            
            var type = parts[0];
            
            try
            {
                switch (type)
                {
                    case "EBook":  // Capital B
                        return new Domain.Media.EBook(
                            title: parts[1] ?? "",
                            author: parts[2] ?? "",
                            language: parts[3] ?? "",
                            pages: ParseInt(parts[4]),
                            year: ParseInt(parts[5]),
                            isbn: parts[6] ?? ""
                        );
                        
                    case "Movie":
                        return new Domain.Media.Movie(
                            title: parts[1] ?? "",
                            director: parts[7] ?? "",
                            genres: parts[8],
                            releaseYear: ParseInt(parts[24]),
                            language: parts[3] ?? "",
                            duration: ParseInt(parts[9])
                        );
                        
                    case "Song":
                        return new Domain.Media.Song(
                            title: parts[1] ?? "",
                            composer: parts[10] ?? "",
                            singer: parts[11] ?? "",
                            genre: parts[13] ?? "",
                            fileType: parts[12] ?? "",
                            duration: ParseInt(parts[9]),
                            language: parts[3] ?? ""
                        );
                        
                    case "VideoGame":
                        return new Domain.Media.VideoGame(
                            title: parts[1] ?? "",
                            genre: parts[13] ?? "",
                            publisher: parts[14] ?? "",
                            releaseYear: ParseInt(parts[24]),
                            supportedPlatforms: parts[15] ?? ""
                        );
                        
                    case "App":
                        return new Domain.Media.App(
                            title: parts[1] ?? "",
                            version: parts[16] ?? "",
                            publisher: parts[14] ?? "",
                            platforms: parts[15],
                            fileSize: ParseDouble(parts[17])
                        );
                        
                    case "Podcast":
                        return new Domain.Media.Podcast(
                            title: parts[1] ?? "",
                            releaseYear: ParseInt(parts[24]),
                            hosts: parts[21],
                            guests: parts[22],
                            episodeNumber: ParseInt(parts[23]),
                            language: parts[3] ?? ""
                        );
                        
                    case "Image":
                        return new Domain.Media.Image(  // Fully qualified to avoid conflict
                            title: parts[1] ?? "",
                            resolution: parts[18] ?? "",
                            fileFormat: parts[19] ?? "",
                            fileSize: ParseDouble(parts[17]),
                            dateTaken: ParseDateTime(parts[20])
                        );
                        
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating {type}: {ex.Message}");
                return null;
            }
        }

        public void SaveAll(List<Domain.Media.Media> Medias)
        {
            try
            {
                var lines = new List<string>
                {
                    "Type,Title,Author,Language,Pages,Year,ISBN,Director,Genres,Duration,Composer,Singer,FileType,Genre,Publisher,Platforms,Version,FileSize,Resolution,FileFormat,DateTaken,Hosts,Guests,EpisodeNumber,ReleaseYear,Ratings"
                };
                
                foreach (var item in Medias)
                {
                    lines.Add(SerializeMedia(item));
                }
                
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving media: {ex.Message}");
            }
        }

        private string SerializeMedia(Domain.Media.Media media)
        {
            var parts = new string[26];
            for (int i = 0; i < parts.Length; i++) parts[i] = "";
            
            parts[1] = EscapeCsv(media.Title);
            
            if (media is Domain.Media.EBook ebook)
            {
                parts[0] = "EBook";
                parts[2] = EscapeCsv(ebook.Author);
                parts[3] = EscapeCsv(ebook.Language);
                parts[4] = ebook.Pages.ToString();
                parts[5] = ebook.Year.ToString();
                parts[6] = EscapeCsv(ebook.ISBN);
            }
            else if (media is Domain.Media.Movie movie)
            {
                parts[0] = "Movie";
                parts[7] = EscapeCsv(movie.Director);
                parts[8] = EscapeCsv(string.Join(";", movie.Genres));
                parts[24] = movie.ReleaseYear.ToString();
                parts[3] = EscapeCsv(movie.Language);
                parts[9] = movie.Duration.ToString();
            }
            else if (media is Domain.Media.Song song)
            {
                parts[0] = "Song";
                parts[10] = EscapeCsv(song.Composer);
                parts[11] = EscapeCsv(song.Singer);
                parts[13] = EscapeCsv(song.Genre);
                parts[12] = EscapeCsv(song.FileType);
                parts[9] = song.Duration.ToString();
                parts[3] = EscapeCsv(song.Language);
            }
            else if (media is Domain.Media.VideoGame game)
            {
                parts[0] = "VideoGame";
                parts[13] = EscapeCsv(game.Genre);
                parts[14] = EscapeCsv(game.Publisher);
                parts[24] = game.ReleaseYear.ToString();
                parts[15] = EscapeCsv(string.Join(";", game.SupportedPlatforms));
            }
            else if (media is Domain.Media.App app)
            {
                parts[0] = "App";
                parts[16] = EscapeCsv(app.Version);
                parts[14] = EscapeCsv(app.Publisher);
                parts[15] = EscapeCsv(string.Join(";", app.Platforms));
                parts[17] = app.FileSize.ToString();
            }
            else if (media is Domain.Media.Podcast podcast)
            {
                parts[0] = "Podcast";
                parts[24] = podcast.ReleaseYear.ToString();
                parts[21] = EscapeCsv(string.Join(";", podcast.Hosts));
                parts[22] = EscapeCsv(string.Join(";", podcast.Guests));
                parts[23] = podcast.EpisodeNumber.ToString();
                parts[3] = EscapeCsv(podcast.Language);
            }
            else if (media is Domain.Media.Image image)
            {
                parts[0] = "Image";
                parts[18] = EscapeCsv(image.Resolution);
                parts[19] = EscapeCsv(image.FileFormat);
                parts[17] = image.FileSize.ToString();
                parts[20] = image.DateTaken.ToString("yyyy-MM-dd");
            }
            
            return string.Join(",", parts);
        }

        // Helper methods for safe parsing
        private int ParseInt(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        private double ParseDouble(string value)
        {
            return double.TryParse(value, out double result) ? result : 0.0;
        }

        private DateTime ParseDateTime(string value)
        {
            return DateTime.TryParse(value, out DateTime result) ? result : DateTime.Now;
        }
        

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var current = new System.Text.StringBuilder();
            
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (line[i] == ',' && !inQuotes)
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(line[i]);
                }
            }
            result.Add(current.ToString());
            
            return result.ToArray();
        }
    }
}
