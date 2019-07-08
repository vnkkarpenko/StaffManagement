using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using StaffManagement.Core.Entities;
using StaffManagement.Interfaces;
using StaffManagement.Logic.Services;
using StaffManagement.Util;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly Helper _helper = new Helper();
        private readonly IStaffRepository _staffRep;

        public HomeController(IStaffRepository staffRep)
        {
            _staffRep = staffRep;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]   
        [AllowAnonymous]   
        public ActionResult ShowDialogEmployee(int employeeId)
        {
            ViewBag.PositionNames = _helper.ListToSelectList(_staffRep.GetPositionNames().dataPosition);
            ViewBag.SubdivisionNames = _helper.ListToSelectList(_staffRep.GetSubdivisionNames().dataSubdivision);
            ViewBag.StatusList =  _helper.GetStatusList();

            var model = employeeId >= 0 ? _staffRep.GetEmployeeById(employeeId).employee : new NewEmployeeViewModel();

            return PartialView("_editEmployee", model);
        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetStaffData()
        {                    
            const int pageSize = 5;
            var pageNumber = Request["page"] == null ? 1 : (int.Parse(Request["page"])); 
            var (tableData, staffData, message) = _staffRep.GetStaffData();

            ViewBag.ErrorMessage = message;
            ViewBag.StaffStatInfo = StaffStatInfo.GetInfo(staffData);

            return PartialView("_staffTable", tableData.OrderByDescending(o => o.Id).ToPagedList(pageNumber, pageSize));
        }  

        [HttpPost]   
        [AllowAnonymous]   
        [ValidateAntiForgeryToken]   
        public async Task<ActionResult> AddOrChangeEmployee(NewEmployeeViewModel model)   
        {   
            if (ModelState.IsValid)   
            {
                var (isSave, message) = await _staffRep.AddOrChangeEmployeeAsync(model);

                if (isSave)
                    return RedirectToAction("Index");

                ViewBag.ErrorMessage = message;
            }   

            return RedirectToAction("Index");
        }
    }
}