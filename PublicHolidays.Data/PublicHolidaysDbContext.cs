using Microsoft.EntityFrameworkCore;
using PublicHolidays.Core.Models;
using PublicHolidays.Data.Configurations;

namespace PublicHolidays.Data
{
    public class PublicHolidaysDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public PublicHolidaysDbContext(DbContextOptions<PublicHolidaysDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new HolidayConfiguration());
        }
    }
}
