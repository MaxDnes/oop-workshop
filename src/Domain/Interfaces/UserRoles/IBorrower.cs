namespace oop.Domain.Interfaces.UserRoles;
using Media;

public interface IBorrower
{
    void BorrowMedia(Media media);
    void ReturnMedia(Media media);
    void RateMedia(Media media, int value);
    void SortMedia(string media);
}