using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RatingDemo.Data.EntityFramework
{
    public class RatingDBContextFactory : IDesignTimeDbContextFactory<RatingDBContext>
    {
        public RatingDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("RatingDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<RatingDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RatingDBContext(optionsBuilder.Options);
        }
    }
}