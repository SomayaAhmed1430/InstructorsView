using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class InstructorController : Controller
    {
        Context context = new Context();
        // Instructor/Index
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View("Index", instructors);
        }

        // Instructor/Details/1
        public IActionResult Details(int id)
        {
            var inst = context.Instructors.FirstOrDefault(t => t.Id == id);

            if (inst == null)
                return NotFound();

            return View("Details", inst);
        }

        // Instructor/NewInstructor
        public IActionResult NewInstructor()
        {
            InstructorWithDeptAndCrsListViewModel VM = new()
            {
                DeptList = context.Departments.ToList(),
                CrsList = context.Courses.ToList()
            };
            return View("NewInstructor", VM);
        }

        // Instructor/SaveNew?Name=value&Manger=value
        public IActionResult SaveNew(Instructor InstFromReq)
        {
            if (InstFromReq.Name != null && InstFromReq.Img != null && InstFromReq.Salary != null && InstFromReq.Address != null && InstFromReq.DeptId != null && InstFromReq.CrsId != null)
            {
                context.Instructors.Add(InstFromReq);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            InstructorWithDeptAndCrsListViewModel VM = new()
            {
                Name = InstFromReq.Name,
                Img = InstFromReq.Img,
                Salary = InstFromReq.Salary,
                Address = InstFromReq.Address,
                DeptId = InstFromReq.DeptId,
                CrsId = InstFromReq.CrsId,
                DeptList = context.Departments.ToList(),
                CrsList = context.Courses.ToList()
            };
            return View("NewInstructor", VM);
        }


        //Instructor/Edit/id
        public IActionResult Edit(int id)
        {
            // collect data
            Instructor InstFromDB = context.Instructors.FirstOrDefault(e=>e.Id==id);
            List<Department> DeptList = context.Departments.ToList();
            List<Course> CrsList = context.Courses.ToList();

            // declare view model
            InstructorWithDeptAndCrsListViewModel InstVM = new();

            // mapping
            InstVM.Id = InstFromDB.Id;
            InstVM.Name = InstFromDB.Name;
            InstVM.Img = InstFromDB.Img;
            InstVM.Salary = InstFromDB.Salary;
            InstVM.Address = InstFromDB.Address;
            InstVM.DeptId = InstFromDB.DeptId;
            InstVM.CrsId = InstFromDB.CrsId;
            InstVM.DeptList = DeptList;
            InstVM.CrsList = CrsList;

            // return view model
            return View("Edit", InstVM);// InstFromDB);
        }


        // Instructor/SaveEdit/@Model.Id
        [HttpPost]
        public ActionResult SaveEdit(Instructor InstFromReq) 
        {
            if (InstFromReq.Name != null && InstFromReq.Img != null && InstFromReq.Salary != null && InstFromReq.Address != null && InstFromReq.DeptId != null && InstFromReq.CrsId != null)
            {
                Instructor InstToDB = context.Instructors.FirstOrDefault(e => e.Id == InstFromReq.Id);
                
                InstToDB.Name = InstFromReq.Name;
                InstToDB.Img = InstFromReq.Img;
                InstToDB.Salary = InstFromReq.Salary;
                InstToDB.Address = InstFromReq.Address;
                InstToDB.DeptId = InstFromReq.DeptId;
                InstToDB.CrsId = InstFromReq.CrsId;

                context.SaveChanges();

                return RedirectToAction("Index", "Instructor");
            }
            return View("Edit", InstFromReq);
        }


        // Instructor/Delete/@Model.Id
        public IActionResult Delete(int id)
        {
            var inst = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (inst == null)
                return NotFound();

            context.Instructors.Remove(inst);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
