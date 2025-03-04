using Microsoft.AspNetCore.Components;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;

namespace WebApp.Components.Pages;

public partial class PeopleList(
   // ctor injection
   IPersonRepository personRepository
) : ComponentBase {
   
   private List<Person> _people;

   protected override void OnInitialized() {
      _people = personRepository.SelectAll().ToList();
   }
}