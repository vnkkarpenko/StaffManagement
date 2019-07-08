using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffManagement.Util
{
    public partial class Helper
    {
        public List<SelectListItem> ListToSelectList<T>(IEnumerable<T> list)
        {
            var data = list.Select(s => new SelectListItem
            {
                Value = $"{s.GetType().GetProperty("Id")?.GetValue(s)}",
                Text = $"{s.GetType().GetProperty("Name")?.GetValue(s)}",
                Selected = false
            }).ToList();

            data.Insert(0, new SelectListItem
            {
                Value = $"{-1}",
                Text = ""
            });

            return data;
        }

        public string GetUserIpAddress()
        {
            var context = HttpContext.Current;

            return context?.Request.UserHostAddress ?? "IP address not found";
        }

        public List<SelectListItem> GetStatusList()
        {
            return new List<SelectListItem> {
                new SelectListItem {Text = "", Value = "-1"},
                new SelectListItem {Text = "Работает", Value = "0"},
                new SelectListItem {Text = "Уволен(а)", Value = "1"},
                new SelectListItem {Text = "Ежегодный отпуск", Value = "2"},
                new SelectListItem {Text = "Декретный отпуск", Value = "3"}
            };
        }
    }
}
