using System.Data.Entity.ModelConfiguration;
using StaffManagement.Core.Entities;

namespace StaffManagement.Data.Configurations
{
    internal class StaffConfiguration : EntityTypeConfiguration<Staff>
    {
        public StaffConfiguration()
        {
            ToTable("Staff");
            HasKey(e => e.Id);
            Ignore(x => x.PersonnelNumber);

            Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            Property(x => x.Surname).IsRequired().HasMaxLength(20);
            Property(x => x.Patronymic).IsRequired().HasMaxLength(20);
            Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }

    internal class SubdivisionConfiguration : EntityTypeConfiguration<Subdivision>
    {
        public SubdivisionConfiguration()
        {
            ToTable("Subdivision");
            HasKey(e => e.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(300);
        }
    }

    internal class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("Position");
            HasKey(e => e.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(300);
        }
    }
}
