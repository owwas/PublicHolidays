using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(a => a.CountryCode);

            builder.Ignore(a => a.Regions);
            builder.Ignore(a => a.HolidayTypes);
            builder.Ignore(a => a.FromDate);
            builder.Ignore(a => a.ToDate);

            builder
                .ToTable("Countries");
        }
    }
}