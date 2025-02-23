using Microsoft.EntityFrameworkCore;
using UrlShortnerMicroServices.Model;

namespace UrlShortnerMicroServices.Data
{
    /// <summary>
    /// database context cLASS FOR curd operation for dbcontex
    /// </summary>
    public class UrlShortenerContext : DbContext
    {
        /// <summary>
        /// this is used to creating table
        /// </summary>
        public DbSet<UrlMapping> UrlMappings { get; set; }
        /// <summary>
        /// used to connection will database
        /// </summary>
        /// <param name="optionsBuilder"> instance of dbcontextoptionBuildeer</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AJAX-05\\MSSQLSERVER01;Initial Catalog=UrlShortner;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
