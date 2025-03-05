using Microsoft.AspNetCore.Components;
using WebApp.Core;
using WebApp.Core.DomainModel.Entities;

namespace WebApp.Components.Pages;

public partial class PersonCreate(
   IPersonRepository personRepository, 
   IDataContext dataContext,
   NavigationManager navigation
) : ComponentBase {
   
   private Person _person = new Person();
   private string? _errorMessage = null;
   
   private void HandleValidSubmit(EventArgs e) {
      try {
         personRepository.Add(_person);
         dataContext.SaveAllChanges();
         navigation.NavigateTo("/people");
      }
      catch (Exception ex) {
         _errorMessage = $"Fehler: {ex.Message}";
      }
   }
}