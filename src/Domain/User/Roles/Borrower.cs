using oop.Domain.Interfaces;
using oop.Domain.Interfaces.UserRoles;

namespace oop.Domain.User.Roles;
using Media;
    public class Borrower : User
    {
        // For Extension 4: Borrowed Items
        private List<Media> _borrowedItems;

        public List<Media> BorrowedItems => _borrowedItems;

        public Borrower(string name, int age, string ssn) : base(name, age, ssn)
        {
            _borrowedItems = new List<Media>();
        }

        public override void DisplayRole()
        {
            Console.WriteLine($"Borrower: {Name} - Browse and borrow access");
        }

        // Borrower-specific methods (read-only + rating)
        public void BrowseMedia(Library library)
        {
            var media = library.GetAllMedia();
            Console.WriteLine("\n=== Browse All Media ===");
            
            for (int i = 0; i < media.Count; i++)
            {
                var item = media[i];
                Console.WriteLine($"{i + 1}. {item.Title} ({item.GetType().Name})");
                
                // Show rating if available
                if (item is IRatable ratable)
                {
                    Console.WriteLine($"   Rating: {ratable.GetAverageRating():F1}/5.0");
                }
            }
        }

        public void FilterByType<T>(Library library) where T : Media
        {
            var filtered = library.GetAllMedia().OfType<T>().ToList();
            
            Console.WriteLine($"\n=== {typeof(T).Name} Items ===");
            foreach (var item in filtered)
            {
                Console.WriteLine($"- {item.Title}");
                if (item is IRatable ratable)
                {
                    Console.WriteLine($"  Rating: {ratable.GetAverageRating():F1}/5.0");
                }
            }
        }

        public void SearchMedia(Library library, string searchTerm)
        {
            var results = library.GetAllMedia()
                .Where(m => m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"\n=== Search Results for '{searchTerm}' ===");
            foreach (var item in results)
            {
                Console.WriteLine($"- {item.Title} ({item.GetType().Name})");
            }
        }

        public void RateMedia(Library library, Media media, int rating)
        {
            if (media is IRatable ratable)
            {
                if (rating >= 1 && rating <= 5)
                {
                    ratable.Rate(rating);
                    library.SaveData();
                    Console.WriteLine($"[Borrower] Rated '{media.Title}' with {rating} stars");
                }
                else
                {
                    Console.WriteLine("Rating must be between 1 and 5");
                }
            }
            else
            {
                Console.WriteLine("This media item cannot be rated");
            }
        }

        public void ViewRatings(Library library)
        {
            var ratableMedia = library.GetAllMedia().OfType<IRatable>().ToList();
            
            Console.WriteLine("\n=== Media Ratings ===");
            foreach (var item in ratableMedia)
            {
                if (item is Media Media)
                {
                    Console.WriteLine($"{Media.Title}: {item.GetAverageRating():F1}/5.0");
                }
            }
        }

        // Extension 4: Borrowing functionality
        public void BorrowItem(Library library, Media media)
        {
            if (!_borrowedItems.Contains(media))
            {
                _borrowedItems.Add(media);
                Console.WriteLine($"[Borrower] Borrowed: {media.Title}");
                library.SaveData();
            }
            else
            {
                Console.WriteLine("You have already borrowed this item");
            }
        }

        public void ReturnItem(Library library, Media media)
        {
            if (_borrowedItems.Contains(media))
            {
                _borrowedItems.Remove(media);
                Console.WriteLine($"[Borrower] Returned: {media.Title}");
                library.SaveData();
            }
            else
            {
                Console.WriteLine("You have not borrowed this item");
            }
        }

        public void ViewBorrowedItems()
        {
            Console.WriteLine("\n=== My Borrowed Items ===");
            if (_borrowedItems.Count == 0)
            {
                Console.WriteLine("No items currently borrowed");
            }
            else
            {
                foreach (var item in _borrowedItems)
                {
                    Console.WriteLine($"- {item.Title} ({item.GetType().Name})");
                }
            }
        }
    }

