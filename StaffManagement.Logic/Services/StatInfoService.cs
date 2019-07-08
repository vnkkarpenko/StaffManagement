using System;
using System.Collections.Generic;
using System.Linq;
using StaffManagement.Core.Entities;
using StaffManagement.Logic.Types;

namespace StaffManagement.Logic.Services
{
    public class StaffStatInfo
    {
        public int StaffCount { get; private set; }
        public string AverageSalary { get; private set; }
        public int WorksCount { get; private set; }
        public int FiredCount { get; private set; }
        public int AnnualVacationCount { get; private set; }
        public int MaternityLeaveCount { get; private set; }

        public static StaffStatInfo GetInfo(List<Staff> staffData)
        {
            var info = new StaffStatInfo
            {
                StaffCount = staffData.Count,
                AverageSalary = staffData.Average(a => a.Rate).ToString("N"),
                WorksCount = GetStat(staffData,StatusType.Works),
                FiredCount = GetStat(staffData,StatusType.Fired),
                AnnualVacationCount= GetStat(staffData,StatusType.AnnualVacation),
                MaternityLeaveCount= GetStat(staffData,StatusType.MaternityLeave),
            };

            return info;
        }

        private static readonly Func<List<Staff>, StatusType, int> GetStat = (d, t) => d.Count(c => c.Status == (int) t);
    }
}
