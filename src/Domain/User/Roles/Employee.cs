using oop.Domain.Interfaces.User;

namespace oop.Domain.User.Roles;
using oop.Domain.Media;

    public class Employee : User
    {
        public Employee(string name, int age, string ssn) : base(name, age, ssn)
        {
        }

        public override void DisplayRole()
        {
            Console.WriteLine($"Employee: {Name} - Media management access");
        }

        // Employee-specific methods (media only, no user management)
        public void AddMedia(Library library, Media media)
        {
            Console.WriteLine($"[Employee] Adding media: {media.Title}");
            library.AddMedia(media);
        }

        public void RemoveMedia(Library library, Media media)
        {
            Console.WriteLine($"[Employee] Removing media: {media.Title}");
            library.RemoveMedia(media);
        }

        public void UpdateMedia(Library library, Media media)
        {
            Console.WriteLine($"[Employee] Updating media: {media.Title}");
            // Media is already modified, just save
            library.SaveData();
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

        public void FilterByType<T>(Library library) where T : Media
        {
            var filtered = library.GetAllMedia().OfType<T>().ToList();
            
            Console.WriteLine($"\n=== {typeof(T).Name} Items ===");
            foreach (var item in filtered)
            {
                Console.WriteLine($"- {item.Title}");
            }
        }
    }
