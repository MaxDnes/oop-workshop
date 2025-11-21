using oop.Domain.User;
using oop.Domain.User.Roles;


    public class CsvUserRepository
    {
        private readonly string _filePath;
        
        public CsvUserRepository(string filePath = "var/users.csv")
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "Type,Name,Age,SSN\n");
            }
        }

        public List<User> LoadAll()
        {
            var users = new List<User>();
            
            try
            {
                var lines = File.ReadAllLines(_filePath);
                
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    
                    var parts = lines[i].Split(',');
                    if (parts.Length < 4) continue;
                    
                    var type = parts[0];
                    var name = parts[1];
                    var age = int.Parse(parts[2]);
                    var ssn = parts[3];
                    
                    switch (type)
                    {
                        case "Admin":
                            users.Add(new Admin(name, age, ssn));
                            break;
                        case "Employee":
                            users.Add(new Employee(name, age, ssn));
                            break;
                        case "Borrower":
                            users.Add(new Borrower(name, age, ssn));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
            }
            
            return users;
        }

        public void SaveAll(List<User> users)
        {
            try
            {
                var lines = new List<string> { "Type,Name,Age,SSN" };
                
                foreach (var user in users)
                {
                    var type = user.GetType().Name;
                    lines.Add($"{type},{user.Name},{user.Age},{user.SSN}");
                }
                
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }
    }

