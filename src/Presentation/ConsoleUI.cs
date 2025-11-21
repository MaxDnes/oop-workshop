using oop.Domain.Interfaces;
using oop.Domain.Media;
using oop.Domain.User;
using oop.Domain.User.Roles;

namespace oop.Presentation
{
    public class ConsoleUI
    {
        private readonly Library _library;
        private User _currentUser;

        public ConsoleUI(Library library)
        {
            _library = library;
        }

        public void Start()
        {
            Console.WriteLine("=== Sønderborg Library System ===");
            SelectUserRole();
            
            if (_currentUser != null)
            {
                ShowMainMenu();
            }
        }

        private void SelectUserRole()
        {
            while (true)
            {
                Console.WriteLine("\nSelect your role:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Borrower");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        _currentUser = new Admin("Admin User", 30, "000000-0000");
                        return;
                    case "2":
                        _currentUser = new Employee("Employee User", 25, "000000-0001");
                        return;
                    case "3":
                        _currentUser = new Borrower("Borrower User", 20, "000000-0002");
                        return;
                    case "0":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine($"\n=== Welcome, {_currentUser.Name} ({_currentUser.GetType().Name}) ===");
                
                if (_currentUser is Admin)
                {
                    ShowAdminMenu();
                }
                else if (_currentUser is Employee)
                {
                    ShowEmployeeMenu();
                }
                else if (_currentUser is Borrower)
                {
                    ShowBorrowerMenu();
                }
            }
        }

        private void ShowAdminMenu()
        {
            Console.WriteLine("\n1. Manage Media");
            Console.WriteLine("2. Manage Users");
            Console.WriteLine("3. View All Media");
            Console.WriteLine("0. Logout");
            Console.Write("Choice: ");
            
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    //ManageMedia();
                    break;
                case "2":
                    ManageUsers();
                    break;
                case "3":
                    ViewAllMedia();
                    break;
                case "0":
                    SelectUserRole();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void ShowEmployeeMenu()
        {
            Console.WriteLine("\n1. Add Media");
            Console.WriteLine("2. Remove Media");
            Console.WriteLine("3. View All Media");
            Console.WriteLine("0. Logout");
            Console.Write("Choice: ");
            
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddMedia();
                    break;
                case "2":
                    RemoveMedia();
                    break;
                case "3":
                    ViewAllMedia();
                    break;
                case "0":
                    SelectUserRole();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void ShowBorrowerMenu()
        {
            Console.WriteLine("\n1. Browse Media");
            Console.WriteLine("2. Filter by Type");
            Console.WriteLine("3. Rate Media");
            Console.WriteLine("0. Logout");
            Console.Write("Choice: ");
            
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewAllMedia();
                    break;
                case "2":
                    FilterByType();
                    break;
                case "3":
                    RateMedia();
                    break;
                case "0":
                    SelectUserRole();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void ViewAllMedia()
        {
            var media = _library.GetAllMedia();
            Console.WriteLine("\n=== All Media ===");
            
            for (int i = 0; i < media.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {media[i].Title} ({media[i].GetType().Name})");
            }
        }

        private void AddMedia()
        {
            Console.WriteLine("\n=== Add Media ===");
            Console.WriteLine("Select media type:");
            Console.WriteLine("1. E-Book");
            Console.WriteLine("2. Movie");
            Console.WriteLine("3. Song");
            Console.WriteLine("4. Video Game");
            Console.WriteLine("5. App");
            Console.WriteLine("6. Podcast");
            Console.WriteLine("7. Image");
            Console.Write("Choice: ");
            
            var choice = Console.ReadLine();
            
            Console.Write("Title: ");
            var title = Console.ReadLine();
            
            Media newMedia = null;
            
            switch (choice)
            {
                case "1":
                    Console.Write("Author: ");
                    var author = Console.ReadLine();
                    Console.Write("Language: ");
                    var language = Console.ReadLine();
                    Console.Write("Pages: ");
                    var pages = int.Parse(Console.ReadLine());
                    Console.Write("Year: ");
                    var year = int.Parse(Console.ReadLine());
                    Console.Write("ISBN: ");
                    var isbn = Console.ReadLine();
                    
                    newMedia = new EBook(title, author, language, pages, year, isbn);
                    break;
                    
            }
            
            if (newMedia != null)
            {
                _library.AddMedia(newMedia);
                Console.WriteLine("Media added successfully!");
            }
        }

        private void RemoveMedia()
        {
            ViewAllMedia();
            Console.Write("\nEnter media number to remove: ");
            
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                var media = _library.GetAllMedia();
                if (index > 0 && index <= media.Count)
                {
                    _library.RemoveMedia(media[index - 1]);
                    Console.WriteLine("Media removed successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private void FilterByType()
        {
            Console.WriteLine("\nFilter by type:");
            Console.WriteLine("1. E-Books");
            Console.WriteLine("2. Movies");
            Console.WriteLine("3. Songs");
            
            Console.Write("Choice: ");
            var choice = Console.ReadLine();
            
            var media = _library.GetAllMedia();
            
            switch (choice)
            {
                case "1":
                    var ebooks = media.OfType<EBook>().ToList();
                    foreach (var book in ebooks)
                    {
                        Console.WriteLine($"- {book.Title} by {book.Author}");
                    }

                    Console.ReadKey();
                    break;
            }
        }

        private void RateMedia()
        {
            ViewAllMedia();
            Console.Write("\nEnter media number to rate: ");
            
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                var media = _library.GetAllMedia();
                if (index > 0 && index <= media.Count)
                {
                    var item = media[index - 1];
                    
                    if (item is IRatable ratable)
                    {
                        Console.Write("Enter rating (1-5): ");
                        if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                        {
                            ratable.Rate(rating);
                            _library.SaveData();
                            Console.WriteLine("Rating added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid rating.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This media cannot be rated.");
                    }
                }
            }
        }

        private void ManageUsers()
        {
            Console.WriteLine("\n=== Manage Users ===");
            Console.WriteLine("1. View All Users");
            Console.WriteLine("2. Add User");
            Console.WriteLine("3. Remove User");
            Console.Write("Choice: ");
            
            var choice = Console.ReadLine();
        }
    }
}
