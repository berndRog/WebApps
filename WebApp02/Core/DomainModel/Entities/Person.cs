using WebApi.Core.DomainModel.Entities;
namespace WebApp.Core.DomainModel.Entities;

public class Person: AEntity {
   
   // properties
   public override Guid Id { get; init;  } = Guid.NewGuid();
   public string FirstName { get; private set; } = string.Empty;
   public string LastName  { get; private set; } = string.Empty;
   public string? Email { get; private set; } = null;
   public string? Phone { get; private set; } = null;
   
   // ctor
   public Person() { }
   public Person(Guid id, string firstName, string lastName, string? email = null, string? phone = null) {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Phone = phone;
   }
   
   public void Set(string? email = null, string? phone = null) {
      if(email != null) Email = email;
      if(phone != null) Phone = phone;
   }

   public void Update(string firstName, string lastName, string? email = null, string? phone = null) {
      FirstName = firstName;  
      LastName = lastName;   
      if(email != null) Email = email;
      if(phone != null) Phone = phone;
   }
   
}
