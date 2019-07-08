using System.Data.Entity;
using StaffManagement.Core.Entities;
using StaffManagement.Data.Configurations;

namespace StaffManagement.Data
{
    public class StaffManagementContext : DbContext
    {
        public StaffManagementContext(): base("DefaultConnection") { }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Subdivision> Subdivision { get; set; }
        public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new StaffConfiguration());
            modelBuilder.Configurations.Add(new SubdivisionConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
        }
    }
}
