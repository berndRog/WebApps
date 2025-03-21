using WebApp.Core;
using WebApp.Core.DomainModel.Entities;
namespace WebApp.Data;

public class PeopleRepository(
   IDataContext dataContext   
): IPeopleRepository {
   
   public Person? FindById(Guid id) =>
      dataContext.People.FirstOrDefault(person => 
         person.Id == id);

   public IEnumerable<Person> SelectAll() =>
      dataContext.People;

   public void Add(Person person) {
      dataContext.People.Add(person);
   }

   public void Update(Person updPerson) {
      var person = dataContext.People.FirstOrDefault(person => 
         person.Id == updPerson.Id);
      if (person == null) return;
      person.Update(updPerson.FirstName, updPerson.LastName,
                    updPerson.Email, updPerson.Phone);
   }

   public void Remove(Person person) {
      dataContext.People.Remove(person);
   }
}
