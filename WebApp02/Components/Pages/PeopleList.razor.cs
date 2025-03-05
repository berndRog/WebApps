using Microsoft.AspNetCore.Components;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;

namespace WebApp.Components.Pages;

public partial class PeopleList(
   // ctor injection
   IPeopleRepository peopleRepository
) : ComponentBase {
   
   private List<Person> _people;

   protected override void OnInitialized() {
      _people = peopleRepository.SelectAll().ToList();
   }
}