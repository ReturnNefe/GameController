using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Cocona;
using GameController.Data;
using GameController.Global;
using GameController.Global.Helper;

namespace GameController
{
    internal class Program
    {
        static async Task Init(string file = "config.txt")
        {
            using (StreamReader reader = new(file, Encoding.UTF8))
                AppInfo.Setting = JsonSerializer.Deserialize<Setting>(await reader.ReadToEndAsync(), AppInfo.JsonOptions) ?? new();
        }
        
        static async Task Main(string[] args)
        {
            void NoDevelopmentAction(IWebHostEnvironment environment, Action action)
            {
                if (!environment.IsDevelopment())
                    action();
            };

            // Parse Arguments
            var cocona = CoconaLiteApp.Create();
            cocona.AddCommand(async ([Option("config", Description = "The config file to load (default is config.txt)")] string? configFile,
                                     [Option("url", Description = "The URL that the HTTP server should use")] string? url,
                                     [Option("no-auto-open", Description = "Whether to open a webpage after the program starts (default is enalbed)"),] bool? noAutoOpen) =>
            {
                AppInfo.Url = url ?? $"http://localhost:{TcpHelper.GetAvailablePort()}";
                AppInfo.AutoOpen = !(noAutoOpen ?? false);
                
                // Init
                await Init(configFile ?? "config.txt");
                
                // Blazor Default
                // Intercept Command Arguments
                var builder = WebApplication.CreateBuilder(Array.Empty<string>());

                // Add services to the container.
                builder.Services.AddRazorPages();
                builder.Services.AddServerSideBlazor();
                builder.Services.AddSingleton<WeatherForecastService>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                NoDevelopmentAction(app.Environment, () =>
                {
                    app.UseExceptionHandler("/Error");

                    // Use Customized Url
                    app.Urls.Add(AppInfo.Url);
                });

                app.UseStaticFiles();

                app.UseRouting();

                app.MapBlazorHub();
                app.MapFallbackToPage("/_Host");

                // Run Blazor Server
                var task = app.RunAsync();

                NoDevelopmentAction(app.Environment, () =>
                {
                    if (AppInfo.AutoOpen)
                        Process.Start(new ProcessStartInfo()
                        {
                            // Replace * -> localhost
                            FileName = AppInfo.Url.Replace("*", "localhost") + (AppInfo.AutoOpen && url == null ? "/desktop" : ""),
                            UseShellExecute = true
                        });
                });
                
                await task;
            });
            
            await cocona.RunAsync();
        }
    }
}