using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using StaffManagement.Logic.Types;


namespace StaffManagement.Logic
{
    public partial class Helper
    {
        public IQueryable<T> OrderByField<T>(IQueryable<T> q, string sortField, bool ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            var method = ascending ? "OrderBy" : "OrderByDescending";
            var types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

            return q.Provider.CreateQuery<T>(mce);
        }

        public string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];

            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            var num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(byteCount) * num) + suf[place];
        }

        private static string GetEnumDescription(Enum en)
        {
            var type = en.GetType();
            var strInfo = type.GetMember(en.ToString());

            if (strInfo.Length > 0)
            {
                var attrs = strInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public string GetStatusNameFromDescription(int status)
        {
            switch (status)
            {
                case 0:
                    return GetEnumDescription(StatusType.Works);
                case 1:
                    return GetEnumDescription(StatusType.Fired);
                case 2:
                    return GetEnumDescription(StatusType.AnnualVacation);
                case 3:
                    return GetEnumDescription(StatusType.MaternityLeave);
            }
            return GetEnumDescription(StatusType.Fired);
        }
        
        public byte[] CreateMd5(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return hashBytes;
        }

        public string CreateMd5ToString(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
