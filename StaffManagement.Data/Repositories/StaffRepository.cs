using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using StaffManagement.Core.Entities;
using StaffManagement.Interfaces;
using StaffManagement.Logic;

namespace StaffManagement.Data.Repositories
{
    public class StaffRepository: IStaffRepository
    {
        private readonly Helper _helper = new Helper();

        public (List<TableStaffViewModel> tableData, List<Staff> staffData, string message) GetStaffData()
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = db.Staff.AsNoTracking().ToList();
                    var tableData = data.Select((s,i) => new TableStaffViewModel
                        {
                            Id = i+1,
                            EmployeeId = s.Id,
                            FirstName = s.FirstName,
                            Surname = s.Surname,
                            Patronymic = s.Patronymic,
                            BirthDate = s.BirthDate.ToString("d"),
                            PersonnelNumber = s.PersonnelNumber,
                            Rate = $"{s.Rate}",
                            Status = _helper.GetStatusNameFromDescription(s.Status),
                            Email = s.Email,
                            Position = GetPositionNameById(s.PositionId).Name ?? "Нет данных",
                            Subdivision = GetSubdivisionNameById(s.SubdivisionId).Name ?? "Нет данных"
                        })
                        .ToList();

                    return (tableData, data, "");
                }
            }
            catch (Exception ex)
            {
                return (null, null, ex.Message);
            }
        }

        public async Task<(bool isSave, string message)> AddOrChangeEmployeeAsync(NewEmployeeViewModel item)
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = new Staff
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        Surname = item.Surname,
                        Patronymic = item.Patronymic,
                        BirthDate = DateTime.Parse(item.BirthDate),
                        Rate = item.Rate,
                        Status = Convert.ToInt32(item.Status),
                        Email = item.Email,
                        PositionId = Convert.ToInt32(item.Position),
                        SubdivisionId = Convert.ToInt32(item.Subdivision),
                        CreateDateTime = DateTime.Now
                    };

                    db.Staff.AddOrUpdate(data);
                    await db.SaveChangesAsync();

                    return (true, "");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        
        public (NewEmployeeViewModel employee, string message) GetEmployeeById(int id)
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var item = db.Staff.AsNoTracking().FirstOrDefault(f => f.Id == id);
                    if (item != null)
                    {
                        var emdata = new NewEmployeeViewModel
                        {
                            Id = item.Id,
                            FirstName = item.FirstName,
                            Surname = item.Surname,
                            Patronymic = item.Patronymic,
                            BirthDate = item.BirthDate.ToString("d"),
                            Rate = item.Rate,
                            Status = $"{item.Status}",
                            Email = item.Email,
                            Position = $"{item.PositionId}",
                            Subdivision = $"{item.SubdivisionId}"
                        };

                        return (emdata, "");
                    }
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }

            return (null, null);
        }


        private Position GetPositionNameById(int id)
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = db.Position.AsNoTracking().FirstOrDefault(f => f.Id == id);

                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public (List<Position> dataPosition, string message) GetPositionNames()
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = db.Position.AsNoTracking().ToList();

                    return (data, "");
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        //private Func<DbQuery<Subdivision>, int, string> _getSubdivisionNameById = (data, id) => data.FirstOrDefault(p => p.Id == id)?.Name ?? "Нет данных";

        private Subdivision GetSubdivisionNameById(int id)
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = db.Subdivision.AsNoTracking().FirstOrDefault(f => f.Id == id);

                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public (List<Subdivision> dataSubdivision, string message) GetSubdivisionNames()
        {
            try
            {
                using (var db = new StaffManagementContext())
                {
                    var data = db.Subdivision.AsNoTracking().ToList();

                    return (data, "");
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
