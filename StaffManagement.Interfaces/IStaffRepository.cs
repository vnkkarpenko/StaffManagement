using System.Collections.Generic;
using System.Threading.Tasks;
using StaffManagement.Core.Entities;

namespace StaffManagement.Interfaces
{
    public interface IStaffRepository
    {
        (List<TableStaffViewModel> tableData, List<Staff> staffData, string message) GetStaffData();        
        (List<Position> dataPosition, string message) GetPositionNames();
        (List<Subdivision> dataSubdivision, string message) GetSubdivisionNames();
        (NewEmployeeViewModel employee, string message) GetEmployeeById(int id);

        Task<(bool isSave, string message)> AddOrChangeEmployeeAsync(NewEmployeeViewModel item);
    }
}
