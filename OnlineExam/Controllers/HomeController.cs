using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExam.Controllers
{
    public class HomeController : Controller
    {
        private OnlineExamEntities ER = new OnlineExamEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tblUserRegister UR)
        {
            ER.tblUserRegisters.Add(UR);
            ER.SaveChanges();
            Int32 UserId = UR.UserId;
            Response.Write(UserId);
            return View();
        }

        public ActionResult UsersList()
        {
            return View(from record in ER.UsersViews select record);
        }

        [HttpGet]
        public ActionResult Delete(Int32 UserId)
        {
            ER.sp_UserDelete(UserId);
            return RedirectToAction("UsersList");
        }

        [HttpGet]
        public ActionResult Edit(Int32 UserId)
        {
            tblUserRegister UR = ER.tblUserRegisters.Find(UserId);
            return View(UR);
        }

        [HttpPost]
        public ActionResult Edit(tblUserRegister UR)
        {
            //ER.sp_Update_UserInfo(UR.UserId, UR.UserName, UR.Password, UR.Email, UR.DOB);
            return View(UR);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblUserRegister UR)
        {
            //int? UserId = ER.ValidateUser(UR.UserName, UR.Password).FirstOrDefault();
            var user = ER.UsersViews.Where(u => u.UserName == UR.UserName && u.Password == UR.Password).FirstOrDefault();
            return View();
        }
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

        //    return View();
        //}

    }
}