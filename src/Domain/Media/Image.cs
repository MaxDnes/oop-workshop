namespace oop.Domain.Media  // Make sure namespace is explicit
{
    public class Image : Media
    {
        public string Resolution { get; set; }
        public string FileFormat { get; set; }
        public double FileSize { get; set; }
        public DateTime DateTaken { get; set; }
        
        public Image(string title, string resolution, string fileFormat, 
            double fileSize, DateTime dateTaken) : base(title)
        {
            Resolution = resolution;
            FileFormat = fileFormat;
            FileSize = fileSize;
            DateTaken = dateTaken;
        }
    }
}