using Ninject.Modules;
using StaffManagement.Data.Repositories;
using StaffManagement.Interfaces;

namespace StaffManagement.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IStaffRepository>().To<StaffRepository>();
        }
    }
}