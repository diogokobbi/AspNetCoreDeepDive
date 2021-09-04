using AspNetCoreDeepDive.SimpleWebApi.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

// Host setup: responsible for app startup and lifetime management
Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(setup =>
    {
        setup.ConfigureServices(services =>
        {
            services.AddSingleton<RecipesService>();
        });
        setup.Configure(app =>
        {
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                var recipesService = e.ServiceProvider.GetRequiredService<RecipesService>();
                e.MapGet("/recipes", async c => await c.Response.WriteAsJsonAsync(await recipesService.GetAll()));
            });
        });
    })
    .Build()
    .Run();