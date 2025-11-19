using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class App : Media, IExecutable
{
    private string Version { get; set; }
    private string Publisher { get; set; }
    private string Platform { get; set; }
    private double FileSize { get; set; }

    public App(string title, string version, string publisher, string platform, double fileSize)
        : base(title)
    {
      Version = version;
      Publisher = publisher;
      Platform = platform;
      FileSize = fileSize;
        }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}