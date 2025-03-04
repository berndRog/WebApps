using WebApp01.Components;

namespace WebApp01;

public class Program {
   public static void Main(string[] args) {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddRazorComponents()
         .AddInteractiveServerComponents();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment()) {
         app.UseExceptionHandler("/Error");
      }
      app.UseAntiforgery();
      
      // Enable serving static files
      app.UseStaticFiles(); 

      app.MapStaticAssets();
      app.MapRazorComponents<App>()
         .AddInteractiveServerRenderMode();
      
      app.Run();
   }
}