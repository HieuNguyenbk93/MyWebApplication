using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class QuestionController : Controller
    {
        DbConnectContext _db = new DbConnectContext();
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListTest()
        {
            try
            {
                IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John" },
                    new Student() { StudentID = 2, StudentName = "Moin" },
                    new Student() { StudentID = 3, StudentName = "Bill" },
                    new Student() { StudentID = 4, StudentName = "Ram" },
                    new Student() { StudentID = 5, StudentName = "Ron"  }
                };
                return Json(studentList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public ActionResult GetList()
        {
            try
            {
                var ListQuestion = _db.Question.Where(x => x.Id > 0).ToList();
                return Json(ListQuestion, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}