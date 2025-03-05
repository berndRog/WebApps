using WebApp.Core.DomainModel.Entities;
namespace WebApp.Core;

public interface IDataContext {
   public ICollection<Person> People { get; }
   public void SaveAllChanges();
}