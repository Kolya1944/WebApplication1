using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.Models;
using System;

// Метод для налаштування програми
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run(); // Створюємо і запускаємо хост
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.Run(async context =>
                    {
                        // Створюємо екземпляр компанії та ініціалізуємо його властивості
                        var company = new Company
                        {
                            Name = "App Innovations",
                            Address = "12th St.",
                            EstablishedYear = 2001,
                            NumberOfEmployees = 300
                        };

                        // Створюємо рядок з інформацією про компанію у форматі JSON
                        var companyInfo = $"{{\"name\":\"{company.Name}\",\"address\":\"{company.Address}\",\"establishedYear\":{company.EstablishedYear},\"numberOfEmployees\":{company.NumberOfEmployees}}}";

                        // Встановлюємо заголовок відповіді і повертаємо інформацію про компанію
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(companyInfo);
                    });
                });
            });
}