using System.Data.Entity.Migrations;
using StaffManagement.Data;

namespace StaffManagement.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StaffManagementContext>
    {
        public Configuration()
        {
#if DEBUG
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
#else
            AutomaticMigrationsEnabled = false;
#endif
        }

        protected override void Seed(StaffManagementContext context)
        {
            //
        }
    }
}
