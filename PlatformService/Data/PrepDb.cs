using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    public static class PrepDb
    {
        //Using for testing data.
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope=app.ApplicationServices.CreateScope())
            {
                seedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void seedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Data...");
                context.Platforms.AddRange(
                    new Platform(){Name="Dot Net",Publisher="Microsoft",Cost="Free"},
                    new Platform(){Name="Sql Server Express",Publisher="Microsoft",Cost="Free"},
                    new Platform(){Name="Kubernetes",Publisher="Cloud Native Computing Foundation",Cost="Free"}
                    
                );
                context.SaveChanges();
            }
            else
            {
                 Console.WriteLine("----> We already have data");
            }

        }
    }
}