using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExam.Controllers
{
    public class AdminController : Controller
    {
        public OnlineExamEntities OE = new OnlineExamEntities();
        // GET: Admin
        public ActionResult AdminDashboard()
        {

            return View();
        }
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(tblCours Course)
        {
            OE.tblCourses.Add(Course);
            OE.SaveChanges();
            return View();
        }

        public ActionResult AddSubject()
        {
            tblSubject MD = new tblSubject();
            MD.CourseList = new SelectList(OE.tblCourses, "CourseID", "CourseName"); // model binding
            return View(MD);
        }

        [HttpPost]
        public ActionResult AddSubject(tblSubject subject)
        {
            OE.tblSubjects.Add(subject);
            OE.SaveChanges();
            //return View();
            return RedirectToAction("AddQuestions");
        }
        public ActionResult AddQuestions()
        {
            tblQuestion QUE = new tblQuestion();
            QUE.SubjectList = new SelectList(OE.tblSubjects, "SubjectID", "SubjectName"); // model binding
            return View(QUE);
        }
        [HttpPost]
        public ActionResult AddQuestions(tblQuestion qes)
        {
            OE.tblQuestions.Add(qes);
            OE.SaveChanges();
            return View();
        }

        public ActionResult AddMenu()
        {
            return View();
        }
    }
}
