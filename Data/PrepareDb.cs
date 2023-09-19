using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepareDb 
    {
        public static void  PreparePopulation(IApplicationBuilder app)
        { 
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                SeedData(context);
            }
        }

        private static void SeedData(AppDbContext context) 
        {
            if(!context.Plataforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Plataforms.AddRange(
                    new Platform(new Guid(), "Dotnet", "Microsoft", "Free"),
                    new Platform(new Guid(), "SQL Server Express", "Microsoft", "Free"),
                    new Platform(new Guid(), "Kubernets", "Cloud Native Computing Foundation", "Free")
                );

                context.SaveChanges();
            }
            else 
                System.Console.WriteLine("--> We already have data.");
        }
    }
}