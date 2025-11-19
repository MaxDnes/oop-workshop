using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Image : Media, IDisplayable

{
    private string Resolution { get; set; }
    private string FileFormat { get; set; }
    private double FileSize { get; set; }
    private string DateTaken { get; set; }

    public Image(string title, string resolution, string fileFormat, double fileSize, string dateTaken)
        : base(title)
    {
        Resolution = resolution;
        FileFormat = fileFormat;
        FileSize = fileSize;
        DateTaken = dateTaken;
    }

    public void Display()
    {
        throw new NotImplementedException();
    }
}