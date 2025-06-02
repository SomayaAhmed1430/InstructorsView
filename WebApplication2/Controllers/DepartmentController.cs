using Microsoft.AspNetCore.Mvc;
using WebApplication2.Migrations;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        Context context = new Context(); 

        // /Department/Index
        public IActionResult Index()
        {
            List<Department> departments = context.Departments.ToList();
            return View("Index", departments);
        }

        // /Department/Details/id
        public IActionResult Details(int id)
        {
            var dept = context.Departments.FirstOrDefault(d=>d.Id == id);

            if (dept == null)
                return NotFound();

            return View("Details", dept);
        }

        // Department/New
        public IActionResult New()
        {
            return View("New");
        }

        // Department/SaveNew?Name=value&Manger=value
        [HttpPost]
        public IActionResult SaveNew(Department DeptFromRequest)//string name, string manger)
        {
            #region done by model binder
            //Department d = new Department();
            //d.Name = name;
            //d.Manager = manger;
            #endregion

            //if (Request.Method == "POST")
            //{
            if (DeptFromRequest.Name != null && DeptFromRequest.Manager != null)
            {
                context.Departments.Add(DeptFromRequest);
                context.SaveChanges();
                //return View("Index");
                //List<Department> departments = context.Departments.ToList();
                //return View("Index", departments);
                return RedirectToAction("Index", "Department");
            }
            return View("New", DeptFromRequest);
            //}
            //return NotFound();
        }

        // /Department/Edit/id
        public IActionResult Edit(int id) 
        {
            Department DeptFromDB = context.Departments.FirstOrDefault(e=>e.Id == id);
            return View("Edit", DeptFromDB);
        }


        // /Department/Edit/id
        [HttpPost]
        public IActionResult SaveEdit(Department DFromReq)
        {
            if (DFromReq.Name != null && DFromReq.Manager != null)
            {
                // get old ref
                Department De = context.Departments.FirstOrDefault(e=>e.Id == DFromReq.Id);
                // check modify based on comming data from request
                De.Name = DFromReq.Name;
                De.Manager = DFromReq.Manager;
                // save changes
                context.SaveChanges();
                // return index
                return RedirectToAction("Index", "Department");
            }
            return View("Edit", DFromReq);
        }
    }
}
