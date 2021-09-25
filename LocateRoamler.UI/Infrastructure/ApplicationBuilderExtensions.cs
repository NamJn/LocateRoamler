using ExcelDataReader;
using LocateRoamler.Data;
using LocateRoamler.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LocateRoamler.Core.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRoutes(this IApplicationBuilder app)
            => app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        public static IApplicationBuilder SeedLocations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LocationDbContext>();
                AddLocations(context);
            }
            return app;
        }
        private static void AddLocations(LocationDbContext context)
        {
            var fileName = @"Locations.xlsx";
            // For .net core, the next line requires the NuGet package, 
            // System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int i = 1;
                    while (reader.Read())
                    {
                        //skip header
                        if (reader.GetValue(0).ToString() == "Address")
                            continue;
                        else
                        {
                            context.Locations.Add(new LocationModel
                            {
                                Id = i++,
                                Name = reader.GetValue(0).ToString(),
                                Latitude = Convert.ToDouble(reader.GetValue(1)),
                                Longitude = Convert.ToDouble(reader.GetValue(2))
                            });
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}

