using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.ViewModel;

namespace WebApplication4.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        private DepartmentDb department = new DepartmentDb();
        public ActionResult Index()
        {
            var dept = department.GetAllDepartments();
            return View(dept);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department dept)

        {
            if (ModelState.IsValid)
            {
                department.CreateDepartment(dept);
                return RedirectToAction("Index");

            }
            return View(dept);
        }
       
        public ActionResult Delete(int id)

        {         
           department.DeleteDepartment(id);
           return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var val = department.GetAllDepartments().Find(e => e.Id == id);
            return View(val);
        }
        [HttpPost]
        public ActionResult Edit(Department dept)
        {
           department.EditDepartment(dept);
            return RedirectToAction("Index");
        }
    }
}