namespace oop.Domain.Media;

public abstract class Media
{
    string Title;
    string Language;
    bool IsBorrowed;
    // TODO: Replace int with borrower
    Dictionary<int,int> Ratings; 
}