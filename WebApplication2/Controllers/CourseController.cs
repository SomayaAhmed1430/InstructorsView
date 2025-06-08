using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CourseController : Controller
    {
        Context context = new Context();

        // Course/index
        public IActionResult Index(int page = 1)
        {
            int pageSize = 3; // 3 courses

            var courses = context.Courses
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            int totalCount = context.Courses.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(courses);
        }


        // Course/Details
        public IActionResult Details(int id) 
        { 
            var crs = context.Courses.FirstOrDefault(c => c.Id == id);

            if (crs == null) 
            { 
                return NotFound();
            }

            return View("Details",crs);
        }


        // Course/New
        public IActionResult New()
        {
            ViewBag.DeptList = context.Departments.ToList();  // ==>
            return View("New");
        }


        // Course/SaveNew/values...
        public ActionResult SaveNew(Course CrsFromReq) 
        {
            if (ModelState.IsValid == true) //&& CrsFromReq.Name != null && CrsFromReq.Degree != null && CrsFromReq.MinDegree != null && CrsFromReq.Hours != null && CrsFromReq.DeptId != null) 
            {
                try
                {
                    context.Courses.Add(CrsFromReq);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) 
                {
                    //ModelState.AddModelError("DeptId", "Please Select Department");
                    ModelState.AddModelError("NewKey", ex.InnerException.Message);
                }
            }
            ViewBag.DeptList = context.Departments.ToList();  // ==>
            return View("New", CrsFromReq);
        }


        // Course/Edit/id
        public IActionResult Edit(int id)
        {
            Course CrsFromDB = context.Courses.FirstOrDefault(c=>c.Id == id);
            ViewBag.DeptList = context.Departments.ToList();
            return View("Edit",CrsFromDB);
        }


        // /Course/Edit/id
        [HttpPost] // handel only internal req not external
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Course CrsFromReq)
        {
            if (CrsFromReq.Name != null && CrsFromReq.Degree != null && CrsFromReq.MinDegree != null && CrsFromReq.Hours != null && CrsFromReq.DeptId != null)
            {
                // get old ref
                Course CrsFromDB = context.Courses.FirstOrDefault(e => e.Id == CrsFromReq.Id);
                // check modify based on comming data from request
                CrsFromDB.Name = CrsFromReq.Name;
                CrsFromDB.Degree = CrsFromReq.Degree;
                CrsFromDB.MinDegree = CrsFromReq.MinDegree;
                CrsFromDB.Hours = CrsFromReq.Hours;
                CrsFromDB.DeptId = CrsFromReq.DeptId;
                // save changes
                context.SaveChanges();
                // return index
                return RedirectToAction("Index", "Course");
            }
            return View("Edit", CrsFromReq);
        }

        // validation
        public IActionResult CheckMinDegree(int MinDegree, int Degree)
        {
            if (MinDegree >= Degree)
                return Json(false);
            return Json(true);
        }

    }
}
