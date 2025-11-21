using oop.Domain.Interfaces;

namespace oop.Domain.Media;

public class EBook : Media  // Capital B
{
    public string Author { get; set; }
    public string Language { get; set; }
    public int Pages { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }
    
    public EBook(string title, string author, string language, 
        int pages, int year, string isbn) : base(title)
    {
        Author = author;
        Language = language;
        Pages = pages;
        Year = year;
        ISBN = isbn;
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