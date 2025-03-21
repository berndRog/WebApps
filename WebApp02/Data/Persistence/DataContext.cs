using System.Text.Json;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;
namespace WebApi01.Data;

public class DataContext: IDataContext {
   // fake storage with JSON file
   private readonly string _filePath;
   private ILogger<DataContext> _logger;
   private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions {
      PropertyNameCaseInsensitive = true,
      WriteIndented = true
   };
   
   public ICollection<Person> People { get; } = [];

   public DataContext(
      ILogger<DataContext> logger
   ) {
      _logger = logger;
      try {
         // Create the directory if it does not exist /Users/rogallab/Webtech/WebApps/WebApp02
         string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
         var directory = Path.Combine(homeDirectory, "Webtech/WebApps/WebApp02");
         if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
         // Create file path
         _filePath = Path.Combine(directory, "people.json");
         _logger.LogInformation("File path: {_filePath}", _filePath);
         if (!File.Exists(_filePath)) 
            File.WriteAllText(_filePath, "[]");
         // Read JSON file and deserialize it
         var json = File.ReadAllText(_filePath);
         _logger.LogInformation("Deserialize: {json}", json);
         People = JsonSerializer.Deserialize<List<Person>>(json, _jsonOptions) ?? new List<Person>();
      }
      catch (Exception e) {
         Console.WriteLine(e.Message);
         throw; // Rethrow the exception
      }
   }

  
   public void SaveAllChanges() {
      try {
         var json = JsonSerializer.Serialize(People, _jsonOptions);
         _logger.LogInformation("Serialize: {json}", json);
         File.WriteAllText(_filePath, json);
      }
      catch (Exception e) {
         Console.WriteLine(e.Message);
         throw; // Rethrow the exception
      }
   }
}
