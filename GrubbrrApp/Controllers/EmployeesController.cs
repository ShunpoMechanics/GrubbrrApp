using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrubbrrApp.DAL;
using GrubbrrApp.Models;

namespace GrubbrrApp.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
            List<Role> roles = db.Roles.ToList();
            List<Skill> skills = db.Skills.ToList();
            //Get RoleName and SkillNames for List View
            foreach (Employee employee in employees)
            {
                employee.getRoleName(roles);
                employee.UnParseEmployeeSkills(skills);
            }
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            employee.SkillsArr = db.Skills.ToList();
            ViewBag.Roles = db.Roles.ToList();
            employee.HobbiesArr = db.Hobbies.ToList();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,BirthDate,JoinDate,Gender,About, Role, Skills, Hobbies")] Employee employee, int[] skillsArr, int[] hobbiesArr)
        {
            if (ModelState.IsValid)
            {
                if (skillsArr != null && hobbiesArr != null)
                {
                    employee.Skills = string.Join(",", skillsArr);
                    employee.Hobbies = string.Join(",", hobbiesArr);
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = employee.Role;
            ViewBag.BirthDate = ((DateTime)employee.BirthDate).ToString("yyyy-MM-dd");
            ViewBag.JoinDate = ((DateTime)employee.JoinDate).ToString("yyyy-MM-dd");
            employee.SkillsArr = db.Skills.ToList();
            ViewBag.selectedSkills = employee.Skills.Split(',').Select(Int32.Parse).ToList();
            ViewBag.selectedHobbies = employee.Hobbies.Split(',').Select(Int32.Parse).ToList();
            ViewBag.Roles = db.Roles.ToList();
            employee.HobbiesArr = db.Hobbies.ToList();
            //Split skills and hobbies into something I can use in the View to prepopulate fields
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,BirthDate,JoinDate,Gender,About, Role, Skills, Hobbies")] Employee employee, int[] skillsArr, int[] hobbiesArr)
        {
            if (ModelState.IsValid)
            {
                employee.Skills = string.Join(",", skillsArr);
                employee.Hobbies = string.Join(",", hobbiesArr);
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Redirect to Index upon pressing cancel
        [HttpPost]
        public ActionResult Cancel(Employee employee) {
            return RedirectToAction("Index", "EmployeeController");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
