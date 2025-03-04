using Microsoft.AspNetCore.HttpLogging;
using WebApi01.Data;
using WebApp.Core;
using WebApp.Data;
using WebApp.Components;

namespace WebApp;

public class Program {
   public static void Main(string[] args) {
      var builder = WebApplication.CreateBuilder(args);
      
      // add http logging 
      builder.Services.AddHttpLogging(opts =>
         opts.LoggingFields = HttpLoggingFields.All);
      
      // Add services to the container.
      builder.Services.AddRazorComponents()
         .AddInteractiveServerComponents();

      builder.Services.AddScoped<IPersonRepository, PersonRepository>();
      builder.Services.AddScoped<IDataContext,DataContext>();
      
      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment()) {
         app.UseExceptionHandler("/Error");
      }

      app.UseAntiforgery();

      app.MapStaticAssets();
      app.MapRazorComponents<App>()
         .AddInteractiveServerRenderMode();

      app.Run();
   }
}