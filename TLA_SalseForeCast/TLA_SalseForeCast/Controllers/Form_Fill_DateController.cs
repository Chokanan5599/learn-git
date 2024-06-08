using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TLA_SalseForeCast.Models;

namespace TLA_SalseForeCast.Controllers
{
    public class Form_Fill_DateController : Controller
    {
        #region EntityFrameworkCore
        private readonly ILogger<HomeController> _logger;
        private readonly M_TAAX63TEST_DB _Set_Dirpersonname;
        private readonly M_TAAX63TEST_DB _Set_Dirpersonname2;
        private readonly M_TAAX63TEST_DB _Set_Dirpersonuser;
        private readonly M_TAAX63TEST_DB _Set_Dirpersonuser2;
        private readonly M_TAAX63TEST_DB _Set_Hcmworker;
        private readonly M_TAAX63TEST_DB _Set_Hcmworker2;
        private readonly M_TAAX63TEST_DB _Set_Etp_OC_Team;
        private readonly M_TAAX63TEST_DB _Set_Etp_OC_Team2;
        public Form_Fill_DateController(ILogger<HomeController> logger, M_TAAX63TEST_DB DIRPERSONNAME, M_TAAX63TEST_DB DIRPERSONUSER, M_TAAX63TEST_DB HCMWORKER, M_TAAX63TEST_DB ETP_OC_TEAM)
        {   //logger Defalfe
            _logger = logger;
            _Set_Dirpersonname = DIRPERSONNAME;
            _Set_Dirpersonname2 = DIRPERSONNAME;

            _Set_Dirpersonuser = DIRPERSONUSER;
            _Set_Dirpersonuser2 = DIRPERSONUSER;
            _Set_Hcmworker = HCMWORKER;
            _Set_Hcmworker2 = HCMWORKER;
            _Set_Etp_OC_Team = ETP_OC_TEAM;
            _Set_Etp_OC_Team2 = ETP_OC_TEAM;
        }

        #endregion

        #region View
        public IActionResult Form_Fill_Date()
        {
            return View();
        }
        #endregion

        #region Action Method
        [HttpGet]
        public async Task<IActionResult> Get_Form_Fill_Date(string user_Id, string _class, string company, string foreCast_user_Id)
        {
            List<M_TAAX63TEST_DB> user_Fill_Date = new List<M_TAAX63TEST_DB>();
            List<Form_Fill> list_data_Form = new List<Form_Fill>();
            try
            {
                //Director
                if (_class == "Director")
                {
                    var fill_Director = (
                    #region INNER JOIN && LEFT JOIN
                        //from a in _Set_Dirpersonname.DIRPERSONNAME
                        //       .Where(v => v.VALIDFROM == _Set_Dirpersonname.DIRPERSONNAME
                        //       .Select(o => o.VALIDFROM).Max())


                        // from a in _Set_Dirpersonname.DIRPERSONNAME
                        /*from a_max_VALIDFROM in _Set_Dirpersonname2.DIRPERSONNAME
                             .Where(m => m.PERSON == a.PERSON)
                             .OrderByDescending(m => m.VALIDFROM).Take(1)*/

                        /* join b in _Set_Hcmworker.HCMWORKER on a.PERSON equals b.PERSON into tb_1
                         from result1 in tb_1.DefaultIfEmpty()

                         join c in _Set_Dirpersonuser.DIRPERSONUSER on a.PERSON equals c.PERSONPARTY into tb_2
                         from result2 in tb_2.DefaultIfEmpty()


                         join d in _Set_Dirpersonuser.ETP_OC_TEAM//.Where(d=> d.ETP_TEAM != 0 && d.DATAAREA == "etp") 
                            on result1.RECID equals d.EMPLOYEE 
                            //where (d => d.ETP_TEAM != 0) 
                         into tb_3
                         from result3 in tb_3.DefaultIfEmpty()
                        */
                    #endregion
                        from a in _Set_Dirpersonname.DIRPERSONNAME

                        from a2 in _Set_Dirpersonname2.DIRPERSONNAME
                                .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                            o.VALIDFROM == _Set_Dirpersonname.DIRPERSONNAME
                                                .Where(o => o.PERSON == a.PERSON)
                                                .Select(o => o.VALIDFROM).Max())

                        join b in _Set_Hcmworker.HCMWORKER on a.PERSON equals b.PERSON
                        join c in _Set_Dirpersonuser.DIRPERSONUSER on a.PERSON equals c.PERSONPARTY
                        join d in _Set_Dirpersonuser.ETP_OC_TEAM on b.RECID equals d.EMPLOYEE

                        where d.ETP_TEAM != 0 && d.DATAAREA == company
                        select new
                        {
                            pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                            pERSON = a.PERSON,
                            name = a.FIRSTNAME,
                            user = c.USER_,
                            vALIDFROM = a.VALIDFROM
                        }).ToList();
                    foreach (var s in fill_Director)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }
                }
                //Admin
                if (_class == "Admin")
                {
                    var fill_Director = (
                        from a in _Set_Dirpersonname.DIRPERSONNAME

                        from a2 in _Set_Dirpersonname2.DIRPERSONNAME
                                .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                            o.VALIDFROM == _Set_Dirpersonname.DIRPERSONNAME
                                                .Where(o => o.PERSON == a.PERSON)
                                                .Select(o => o.VALIDFROM).Max())

                        join b in _Set_Hcmworker.HCMWORKER on a.PERSON equals b.PERSON
                        join c in _Set_Dirpersonuser.DIRPERSONUSER on a.PERSON equals c.PERSONPARTY
                        join d in _Set_Dirpersonuser.ETP_OC_TEAM on b.RECID equals d.EMPLOYEE

                        where d.ETP_TEAM != 0 && d.DATAAREA == company
                        select new
                        {
                            pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                            pERSON = a.PERSON,
                            name = a.FIRSTNAME,
                            user = c.USER_,
                            vALIDFROM = a.VALIDFROM
                        }).ToList();
                    foreach (var s in fill_Director)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }
                }
                //Leader
                if (_class == "Leader")
                {
                    var fill_Leader = (

                                         from a in _Set_Dirpersonname.DIRPERSONNAME
                                         from a2 in _Set_Dirpersonname2.DIRPERSONNAME
                                             .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&

                                                         o.VALIDFROM == _Set_Dirpersonname.DIRPERSONNAME
                                                             .Where(o => o.PERSON == a.PERSON)
                                                             .Select(o => o.VALIDFROM).Max())

                                         join b in _Set_Hcmworker.HCMWORKER on a.PERSON equals b.PERSON
                                         join c in _Set_Dirpersonuser.DIRPERSONUSER on a.PERSON equals c.PERSONPARTY
                                         join d in _Set_Dirpersonuser.ETP_OC_TEAM on b.RECID equals d.EMPLOYEE

                                         where d.ETP_TEAM != 0
                                         //&& d.DATAAREA == company
                                         select new
                                         {
                                             pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                             pERSON = a.PERSON,
                                             name = a.FIRSTNAME,
                                             user = c.USER_,
                                             vALIDFROM = a.VALIDFROM
                                         }).ToList();
                    var fill_Leader2 = (from br1 in _Set_Dirpersonuser2.DIRPERSONUSER
                                        join br2 in _Set_Hcmworker2.HCMWORKER on br1.PERSONPARTY equals br2.PERSON

                                        join br3 in _Set_Etp_OC_Team2.ETP_OC_TEAM on br2.RECID equals br3.MANAGER
                                        where br1.USER_ == foreCast_user_Id
                                        select new
                                        {
                                            emp_id = Convert.ToInt64(br3.EMPLOYEE)
                                        }).ToList();
                    //var fill_Leader3 = fill_Leader.Where(s => fill_Leader2.ToString().Contains(Convert.ToString(s.pRECID))).ToList();
                    int i;
                    for (i = 0; i < fill_Leader2.Count(); i++)
                    {
                        foreach (var s in fill_Leader)
                        {
                            Form_Fill a = new Form_Fill();
                            if (s.pRECID == fill_Leader2[i].emp_id)
                            {
                                a.RECID = s.pRECID;
                                a.salesName = s.name;
                                a.PERSON = s.pERSON;
                                a.user = s.user;
                                a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                                list_data_Form.Add(a);
                                break;
                            }
                        }
                    }
                }
                //Officer
                if (_class == "Officer")
                {
                    var fill_Officer = (from a in _Set_Dirpersonname.DIRPERSONNAME
                                        from a2 in _Set_Dirpersonname2.DIRPERSONNAME
                                            .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&

                                                        o.VALIDFROM == _Set_Dirpersonname.DIRPERSONNAME
                                                            .Where(o => o.PERSON == a.PERSON)
                                                            .Select(o => o.VALIDFROM).Max())

                                        join b in _Set_Hcmworker.HCMWORKER on a.PERSON equals b.PERSON
                                        join c in _Set_Dirpersonuser.DIRPERSONUSER on a.PERSON equals c.PERSONPARTY
                                        join d in _Set_Dirpersonuser.ETP_OC_TEAM on b.RECID equals d.EMPLOYEE


                                        where d.ETP_TEAM != 0
                                                && (c.USER_ == foreCast_user_Id
                                                && d.DATAAREA == company)
                                        //&& d.DATAAREA == company
                                        select new
                                        {
                                            pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                            pERSON = a.PERSON,
                                            name = a.FIRSTNAME,
                                            user = c.USER_,
                                            vALIDFROM = a.VALIDFROM
                                        }).ToList();

                    foreach (var s in fill_Officer)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }

                }

                return new OkObjectResult(new { data = list_data_Form });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult GetSession(string userName)
        {

            try
            {
                HttpContext.Session.SetString("UserName", userName);
                userName = HttpContext.Session.GetString("UserName");
                ViewData["UserName"] = userName;
            }
            catch (Exception ex)
            {
                //throw ex;
                return Ok("NG");
            }
            return Ok("Successful!");
        }
        #endregion
    }
}
