using oop.Domain.Interfaces.User;

namespace oop.Domain.User.Roles;

    public class Admin : User
    {
        public Admin(string name, int age, string ssn) : base(name, age, ssn)
        {
        }

        public override void DisplayRole()
        {
            Console.WriteLine($"Admin: {Name} - Full system access");
        }

        // Admin-specific methods
        public void AddUser(Library library, User user)
        {
            Console.WriteLine($"[Admin] Adding user: {user.Name}");
            // Implementation in Library class
        }

        public void RemoveUser(Library library, User user)
        {
            Console.WriteLine($"[Admin] Removing user: {user.Name}");
            // Implementation in Library class
        }

        public void AddMedia(Library library, Media.Media media)
        {
            Console.WriteLine($"[Admin] Adding media: {media.Title}");
            library.AddMedia(media);
        }

        public void RemoveMedia(Library library, Media.Media media)
        {
            Console.WriteLine($"[Admin] Removing media: {media.Title}");
            library.RemoveMedia(media);
        }

        public void ViewAllUsers(Library library)
        {
            var users = library.GetAllUsers();
            Console.WriteLine("\n=== All Users ===");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.GetType().Name}: {user}");
            }
        }

        public void ViewAllMedia(Library library)
        {
            var media = library.GetAllMedia();
            Console.WriteLine("\n=== All Media ===");
            foreach (var item in media)
            {
                Console.WriteLine($"- {item.GetType().Name}: {item.Title}");
            }
        }

        public void ViewSystemStats(Library library)
        {
            Console.WriteLine("\n=== System Statistics ===");
            Console.WriteLine($"Total Media Items: {library.GetAllMedia().Count}");
            Console.WriteLine($"Total Users: {library.GetAllUsers().Count}");
        }
    }
