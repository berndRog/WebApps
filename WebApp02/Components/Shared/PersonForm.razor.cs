using Microsoft.AspNetCore.Components;
using WebApp.Core.DomainModel.Entities;
namespace WebApp.Components.Shared;

public partial class PersonForm {
   [Parameter]
   public Person Person { get; set; } = new();
   [Parameter]
   public EventCallback<EventArgs> OnValidSubmit { get; set; }

   // Input-Model for Data-Binding bidirectional
   public string FirstName { get; set; } = string.Empty;
   private string LastName { get; set; } = string.Empty;
   private string? Email { get; set; } = null;
   private string? Phone { get; set; } = null;

   private async Task HandleSubmit() {
      // Update the Person object
      Person.Update(FirstName, LastName, Email, Phone);
      
      if (OnValidSubmit.HasDelegate)
         await OnValidSubmit.InvokeAsync(EventArgs.Empty);
   }
}