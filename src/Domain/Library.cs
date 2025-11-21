using oop.Domain.User;
using oop.Domain.Media;
using oop.Persistence;


    public class Library
    {
        private List<Media> _Medias;
        private List<User> _users;
        private readonly CsvMediaRepository _mediaRepo;
        private readonly CsvUserRepository _userRepo;

        public Library()
        {
            _mediaRepo = new CsvMediaRepository();
            _userRepo = new CsvUserRepository();
            LoadData();
        }

        private void LoadData()
        {
            _Medias = _mediaRepo.LoadAll();
            _users = _userRepo.LoadAll();
        }

        public void SaveData()
        {
            _mediaRepo.SaveAll(_Medias);
            _userRepo.SaveAll(_users);
        }

        public void AddMedia(Media item)
        {
            _Medias.Add(item);
            SaveData();
        }

        public void RemoveMedia(Media item)
        {
            _Medias.Remove(item);
            SaveData();
        }

        public List<Media> GetAllMedia() => new List<Media>(_Medias);
        public List<User> GetAllUsers() => new List<User>(_users);
    }
