using Microsoft.EntityFrameworkCore;

namespace URL_Shortener_Engine.Models
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Short_Url> ShortUrls { get; set; }

    }
}
