using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Data.Configurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        //public void Configure(EntityTypeBuilder<Holiday> builder)
        //{
        //    builder
        //        .HasKey(a => a.Id);

        //    builder
        //        .Property(m => m.Id)
        //        .UseIdentityColumn();

        //    builder
        //        .Property(m => m.Name)
        //        .IsRequired()
        //        .HasMaxLength(50);

        //    builder
        //        .ToTable("Holidays");
        //}
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}