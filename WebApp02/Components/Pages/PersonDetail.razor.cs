using Microsoft.AspNetCore.Components;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;
namespace WebApp.Components.Pages;

public partial class PersonDetail(
   // ctor injection
   IPersonRepository personRepository,
   IDataContext dataContext,
   NavigationManager navigation
): ComponentBase {
   
   // @page "/people/{id:guid}"
   [Parameter] public Guid Id { get; set; }
   
   private Person _person = new Person();
   private string? _errorMessage = null;
   
   protected override void OnInitialized() {
      _person = personRepository.FindById(Id);
   }
   
   private void HandleValidSubmit() {
      try {
         // Save the book to the repository
         personRepository.Update(_person);
         dataContext.SaveAllChanges();
      } catch (Exception ex) {
         // Handle the exception
         _errorMessage = $"Fehler: {ex.Message}";
      }

      // Handle the form submission, e.g., save the book to a database
      navigation.NavigateTo("/people");
   }
}