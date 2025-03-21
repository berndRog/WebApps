using Microsoft.AspNetCore.Components;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;

namespace WebApp.Components.Pages;

public partial class PeopleList(
   // ctor injection
   IPeopleRepository peopleRepository
) : ComponentBase {
   
   private List<Person> _people;
   private string? _errorMessage;

   protected override void OnInitialized() {
      _errorMessage = null;
      try {
         _people = peopleRepository.SelectAll().ToList();
      }
      catch (Exception ex) {
         _errorMessage = $"Fehler: {ex.Message}";
      }
   }
}