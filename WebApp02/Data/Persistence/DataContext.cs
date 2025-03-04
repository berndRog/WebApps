using System.Text.Json;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;
namespace WebApi01.Data;

public class DataContext: IDataContext {
   // fake storage with JSON file
   private readonly string _filePath;
   
   public ICollection<Person> People { get; } = [];

   public DataContext(
      ILogger<DataContext> logger
   ) {
      try {
         // Create the directory if it does not exist /Users/rogallab/Webtech/WebApps/WebApp02
         string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
         var directory = Path.Combine(homeDirectory, "Webtech/WebApps/WebApp02");
         if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
         // Create file path
         _filePath = Path.Combine(directory, "people.json");
         logger.LogInformation("File path: {_filePath}", _filePath);
         if (!File.Exists(_filePath)) 
            File.WriteAllText(_filePath, "[]");
         // Read JSON file and deserialize it
         var json = File.ReadAllText(_filePath);
         People = JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
      }
      catch (Exception e) {
         Console.WriteLine(e.Message);
         throw; // Rethrow the exception
      }
   }

  
   public void SaveChanges() {
      try {
         var json = JsonSerializer.Serialize(People);
         File.WriteAllText(_filePath, json);
      }
      catch (Exception e) {
         Console.WriteLine(e.Message);
         throw; // Rethrow the exception
      }
   }
}
