using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.Models;
using System;

// ����� ��� ������������ ��������
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run(); // ��������� � ��������� ����
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.Run(async context =>
                    {
                        // ��������� ��������� ������ �� ���������� ���� ����������
                        var company = new Company
                        {
                            Name = "App Innovations",
                            Address = "12th St.",
                            EstablishedYear = 2001,
                            NumberOfEmployees = 300
                        };

                        // ��������� ����� � ����������� ��� ������� � ������ JSON
                        var companyInfo = $"{{\"name\":\"{company.Name}\",\"address\":\"{company.Address}\",\"establishedYear\":{company.EstablishedYear},\"numberOfEmployees\":{company.NumberOfEmployees}}}";

                        // ������������ ��������� ������ � ��������� ���������� ��� �������
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(companyInfo);
                    });
                });
            });
}