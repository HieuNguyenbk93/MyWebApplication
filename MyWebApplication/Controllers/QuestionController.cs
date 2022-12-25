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
        [HttpGet]
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
        [HttpPost]
        public int Create(Question data)
        {
            try
            {
                var result = _db.Question.Add(data);
                _db.SaveChanges();
                return result.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        [HttpPost]
        public Boolean Update(Question data)
        {
            try
            {
                Question model = _db.Question.Where(x => x.Id == data.Id).SingleOrDefault();
                model.Name = data.Name;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPost]
        public Boolean Delete(Question data)
        {
            try
            {
                var dataDel = _db.Question.Where(x => x.Id == data.Id).FirstOrDefault();
                _db.Question.Remove(dataDel);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}