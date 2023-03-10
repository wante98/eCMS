using eCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace eCMS.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        int pageSize = 10;
        public ActionResult Order(int page = 1)
        {
            var dtos = new List<Orders>();
            int currentPage = page < 1 ? 1 : page;
            var orders = db.Orders.OrderBy(m=>m.OrderID).ToList();
            var result = orders.ToPagedList(currentPage, pageSize);
            ViewBag.Message = "Order";

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            var employee = db.Employees.Where(m=>m.EmployeeID.ToString()== id).FirstOrDefault();
            return View(employee);
        }

        public ActionResult Employee()
        {
            var employees = db.Employees
                .ToList();         
            ViewBag.Message = "Employee List";

            return View(employees);
        }

        

        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.Employees.Where(m => m.EmployeeID == employee.EmployeeID)
                    .FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(employee);
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Employee", "Home");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employees employees)
        {
            if (ModelState.IsValid)
            {
                var temp = db.Employees
                    .Where(m => m.EmployeeID == employees.EmployeeID)
                    .FirstOrDefault();
                temp.LastName = employees.LastName;
                temp.FirstName = employees.FirstName;
                temp.Title = employees.Title;
                temp.TitleOfCourtesy = employees.TitleOfCourtesy;                                                                                                                                                                            
                temp.BirthDate  = employees.BirthDate;
                temp.HireDate = employees.HireDate;
                temp.Address = employees.Address;
                temp.City = employees.City;
                temp.Region = employees.Region;
                temp.PostalCode = employees.PostalCode;
                temp.Country = employees.Country;
                temp.HomePhone = employees.HomePhone;
                temp.Notes = employees.Notes;
                db.SaveChanges();
                return RedirectToAction("Employee", "Home");
            }
            return View(employees);
        }

        public ActionResult Delete(int id)
        {
            var employee = db.Employees
                .Where(m => m.EmployeeID == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Employee","Home");
        }
    }
}