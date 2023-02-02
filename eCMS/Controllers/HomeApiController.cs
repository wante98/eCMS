using eCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace eCMS.Controllers
{
    public class HomeApiController : HomeController
    {

        NorthwindEntities1 db = new NorthwindEntities1();
        // GET: Home
        //public ActionResult Index()
        //{
        //    var employees = db.Employee.ToList();
        //    return View(employees);
        //}


       
        //[HttpPost]
        //public ActionResult Create(Employees employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ViewBag.Error = false;
        //        var temp = db.Employees.Where(m => m.EmployeeID == employee.EmployeeID)
        //            .FirstOrDefault();
        //        if (temp != null)
        //        {
        //            ViewBag.Error = true;
        //            return View(employee);
        //        }
        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //public ActionResult Edit(string fEmpId)
        //{
        //    var employee = db.Employees
        //        .Where(m => m.EmployeeID == fEmpId).FirstOrDefault();
        //    return View(employee);
        //}

        //[HttpPost]
        //public ActionResult Edit(Employees employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var temp = db.Employees
        //            .Where(m => m.EmployeeID == employee.EmployeeID)
        //            .FirstOrDefault();
        //        temp.fName = employee.fName;
        //        temp.fSalary = employee.fSalary;
        //        temp.fMail = employee.fMail;
        //        temp.fGender = employee.fGender;
        //        temp.fEmploymentDate = employee.fEmploymentDate;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //public new ActionResult Delete(int EmployeeID)
        //{
        //    var employee = db.Employees
        //        .Where(m => m.EmployeeID == EmployeeID).FirstOrDefault();
        //    db.Employees.Remove(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}