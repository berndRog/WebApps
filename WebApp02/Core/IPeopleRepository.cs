using WebApp.Core.DomainModel.Entities;
namespace WebApp.Core;

public interface IPersonRepository {
   public Person FindById(Guid id);
   public IEnumerable<Person> SelectAll();
   public void Add(Person person);
   public void Update(Person updatedPerson);
   public void Remove(Person person);
}