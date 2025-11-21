using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class App : Media, IExecutable
{
    public string Version { get; set; }
    public string Publisher { get; set; }
    public string Platforms { get; set; }
    public double FileSize { get; set; }
    
    public App(string title, string version, string publisher, 
        string platforms, double fileSize) : base(title)
    {
        Version = version;
        Publisher = publisher;
        Platforms = platforms;
        FileSize = fileSize;
    }

    public void Rate(int result)
    {
        throw new NotImplementedException();
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}