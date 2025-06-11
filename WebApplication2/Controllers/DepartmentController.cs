using Microsoft.AspNetCore.Mvc;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        //Context context = new Context(); 

        // DIP + IOC
        IDepartmentRepository DeptRepository;
        public DepartmentController(IDepartmentRepository deptRepo)
        {
            this.DeptRepository = deptRepo;

            //DeptRepository = new DepartmentRepository();
        }

        // /Department/Index
        public IActionResult Index(int page = 1)
        {
            List<Department> deptList = DeptRepository.GetAll();
            return View("Index", deptList);
        }

        // /Department/Details/id
        public IActionResult Details(int id)
        {
            var dept = DeptRepository.GetByID(id);

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
                DeptRepository.Add(DeptFromRequest);
                DeptRepository.Save();
                return RedirectToAction("Index", "Department");
            }
            return View("New", DeptFromRequest);
            //}
            //return NotFound();
        }

        // /Department/Edit/id
        public IActionResult Edit(int id) 
        {
            Department DeptFromDB = DeptRepository.GetByID(id);
            return View("Edit", DeptFromDB);
        }


        // /Department/Edit/id
        [HttpPost]
        public IActionResult SaveEdit(Department DFromReq)
        {
            if (DFromReq.Name != null && DFromReq.Manager != null)
            {
                // get old ref
                Department De = new Department();
                // check modify based on comming data from request
                De.Id = DFromReq.Id;
                De.Name = DFromReq.Name;
                De.Manager = DFromReq.Manager;
                DeptRepository.Update(De);
                // save changes
                DeptRepository.Save();
                // return index
                return RedirectToAction("Index", "Department");
            }
            return View("Edit", DFromReq);
        }
    }
}
