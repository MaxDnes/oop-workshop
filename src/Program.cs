using System;
using oop.Domain;
using oop.Presentation;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var library = new Library();
                var ui = new ConsoleUI(library);
                ui.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}