namespace oop.Domain.Interfaces.Repository;

public interface IRepository
{
    void SaveMedia(List<Media.Media>  media);
    void LoadMedia(List<Media.Media> media);
    // TODO: replace with User type when done
    void SaveUsers(List<string> users);
    void LoadUsers(List<string> users);
}