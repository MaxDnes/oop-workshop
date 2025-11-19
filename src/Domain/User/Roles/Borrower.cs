using oop.Domain.Interfaces.UserRoles;

namespace oop.Domain.User.Roles;
using Media;

public class Borrower : IBorrower
{
    public List<Media> Medias { get; set; }
    
    public void BorrowMedia(Media media)
    {
        throw new NotImplementedException();
    }

    public void ReturnMedia(Media media)
    {
        throw new NotImplementedException();
    }

    public void RateMedia(Media media, int value)
    {
        throw new NotImplementedException();
    }

    public void SortMedia(string media)
    {
        throw new NotImplementedException();
    }
}