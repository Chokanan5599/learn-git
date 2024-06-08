using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TLA_SalseForeCast.Models;
using System.Text;

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Data.SqlClient;

using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;


namespace TLA_SalseForeCast.Controllers
{
    //[ApiController]
    //[Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string s_Name;
        private string s_UserID;
        private string s_UserPass;
        private string s_Class;
        private readonly M_db _User;
        private readonly M_db _Sales;

        private string userName;

        private readonly M_TAAX63TEST_DB _Set_UserpermissionModel;
        private readonly M_TAAX63TEST_DB _Set_CompanyModel;
        private readonly M_TAAX63TEST_DB _Set_Sysuserinfo;
        private readonly M_TAAX63TEST_DB _Set_Etp_OC_Team;
        private readonly M_TAAX63TEST_DB _Set_Data_Area;
        
        public HomeController(ILogger<HomeController>logger,M_db UserPermission,
            M_db Sales_Responsible,

            M_TAAX63TEST_DB WEB_SALESFORECAST_USERPERMISSION,
            M_TAAX63TEST_DB WEB_SALESFORECAST_COMPANY,
            M_TAAX63TEST_DB SYSUSERINFO,
            M_TAAX63TEST_DB ETP_OC_TEAM,
            M_TAAX63TEST_DB DATAAREA
            )
        {
            _logger = logger;
            _User = UserPermission;
            _Sales = Sales_Responsible;

            _Set_UserpermissionModel = WEB_SALESFORECAST_USERPERMISSION;
            _Set_CompanyModel = WEB_SALESFORECAST_COMPANY;
            _Set_Sysuserinfo = SYSUSERINFO;
            _Set_Etp_OC_Team = ETP_OC_TEAM;
            _Set_Data_Area = DATAAREA;
        }

        #region View
        public IActionResult Index()
        {

           
            return View();
        }
        public IActionResult Login()
        {
           
            return View();
        }

        public IActionResult SalesForeCasst_Dashboard()
        {
            return View();
        }
        public IActionResult SalesForeCasst_Detail()
        {
            return View();
        }
        public IActionResult SalesForeCasst_Customer_List()
        {
            return View();
        }
        #endregion

        #region Action Medthod
        [HttpGet]
        [Route("Home")]
        public JsonResult getLogin(string txt_email, string txt_password, string txt_selected)
        {
            //var user = _User.UserPermission.Where(a => a.Email == txt_email && a.Pass_id == txt_password && a.Company == txt_selected).FirstOrDefault();
            var user = (from a in _Set_UserpermissionModel.WEB_SALESFORECAST_USERPERMISSION

                        join b in _Set_CompanyModel.WEB_SALESFORECAST_COMPANY on a.User_id equals b.User_id into tb_1
                        from Result1 in tb_1.DefaultIfEmpty()

                        join b in _Set_Sysuserinfo.SYSUSERINFO on a.Email equals b.EMAIL into tb_2
                        from Result2 in tb_2.DefaultIfEmpty()

                        where a.Email == txt_email
                        select new
                        {
                            login_User_id = a.User_id,
                            Role = a.Role,
                            Company_Name = Result1.Company_Name,
                            foreCast_User_id = Result2.ID
                        }).FirstOrDefault();
            if (user == null)
            {
                return Json("NG");
            }
            HttpContext.Session.SetString("UserName", user.foreCast_User_id);
            userName = HttpContext.Session.GetString("UserName");
            ViewData["UserName"] = userName;
            return Json(user);
        }
        public IActionResult LogOut()
        {
            //return RedirectToAction("Login");
            string session;
            HttpContext.Session.Clear();
            try
            {
                session = "OK";
                return Json(session);
            }
            catch
            {
                session = "NG";
            }
            return Json(session);
        }
        public JsonResult getCompany(string txt_email)
        {
            //var company = _User.UserPermission.Where(a => a.Email == txt_email).Select(a => new { a.Company }).ToList();
            var set_Role = _Set_UserpermissionModel.WEB_SALESFORECAST_USERPERMISSION.Where(a => a.Email == txt_email).Select(a => new { a.Role }).FirstOrDefault();
            var company = (from a in _Set_UserpermissionModel.WEB_SALESFORECAST_USERPERMISSION

                           join b in _Set_CompanyModel.WEB_SALESFORECAST_COMPANY
                           on a.User_id equals b.User_id into tb_1
                           from Result1 in tb_1.DefaultIfEmpty()

                           join c in _Set_Sysuserinfo.SYSUSERINFO
                           on a.Email equals c.EMAIL into tb_2
                           from Result2 in tb_2.DefaultIfEmpty()

                           where a.Email == txt_email
                           select new
                           {
                               login_User_id = a.User_id,
                               Company_Name = Result1.Company_Name,
                               foreCast_User_id = Result2.ID,
                               user_Type =  a.Role
                           }).ToList();
            if (set_Role == null)
            {
                return Json("NG");
            }
            //if (set_Role.ToString() == "Admin") {

            //}
            //else { }
            //ViewBag.Name = name;
            return Json(new { data1 = company, data2 = set_Role });
        }

        public async Task <IActionResult> getTypeCompanyByAdmin(string txt_email) {
            var company = _Set_Data_Area.DATAAREA.Select(a => new { id = a.ID, name = a.NAME}).ToList();
            try { 
                return new OkObjectResult( new { data = company});
            }
            catch (Exception ex)
            {
                throw (ex);
                //return BadRequest(ex.Message);
            }
        
        }
        public JsonResult getUserForm_Date(int user_Id, string _class, string company)
        {
            //var user_Fill_Date = new List<UserModel>();
            List<UserModel> user_Fill_Date = new List<UserModel>();
            if (_class == "Admin")
            {
                user_Fill_Date = _User.UserPermission.Where(a => a.Company == company).OrderBy(a => a.Class).ToList();
            }
            if (_class == "Director") {

                user_Fill_Date = _User.UserPermission.Where(a => a.Company == company).OrderBy(a => a.Class).ToList();
            }
            else
            {
                user_Fill_Date = _User.UserPermission.Where(a => a.User_id == user_Id && a.Company == company).ToList();
            }
            return Json(user_Fill_Date);
        }
        public JsonResult getSales_Responsible()
        {
            var salse_Respons = _Sales.Sales_Responsible.ToList();
            return Json(new { data = salse_Respons });
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
