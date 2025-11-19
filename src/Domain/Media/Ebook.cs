using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class Ebooks : Media, IReadable
{
    private string Author {  get; set; }
    private int Pages { get; set; } 
    private int PublicationYear { get; set; }
    private string ISBN { get; set; }

    public Ebooks(string title, string author, int pages, int publicationYear, string iSBN)
        : base(title)
    {
    Author = author;
        Pages = pages;
        PublicationYear = publicationYear;
        ISBN = iSBN;

    }

    public void Read()
    {
        throw new NotImplementedException();
    }

    public void View()
    {
        throw new NotImplementedException();
    }
}