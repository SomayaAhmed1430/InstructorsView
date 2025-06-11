using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class CourseController : Controller
    {
        //Context context = new Context();

        // DIP + IOC
        ICourseRepository CrsRepository;
        IDepartmentRepository DeptRepository;
        public CourseController(ICourseRepository crsRepo, IDepartmentRepository deptRepo)  // Ask
        {
            this.CrsRepository = crsRepo;
            this.DeptRepository = deptRepo;

            //CrsRepository = new CourseRepository();  // Dont Create
            //DeptRepository = new DepartmentRepository();
        }

        // Course/index
        public IActionResult Index(int page = 1)
        {
            int pageSize = 3;

            List<Course> pagedCourses = CrsRepository.GetPaged(page, pageSize);
            int totalCount = CrsRepository.GetCount();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View("Index", pagedCourses);

            //List<Course> CrsList = CrsRepository.GetAll();
            //return View("Index", CrsList);
        }


        // Course/Details
        public IActionResult Details(int id) 
        { 
            var crs = CrsRepository.GetByID(id);

            if (crs == null) 
            { 
                return NotFound();
            }

            return View("Details",crs);
        }


        // Course/New
        public IActionResult New()
        {
            ViewBag.DeptList = DeptRepository.GetAll();  // ==>
            return View("New");
        }


        // Course/SaveNew/values...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNew(Course CrsFromReq) 
        {
            if (CrsFromReq.Name != null && CrsFromReq.Degree != null && CrsFromReq.MinDegree != null && CrsFromReq.Hours != null && CrsFromReq.DeptId != null) 
            {
                try
                {
                    CrsRepository.Add(CrsFromReq);
                    CrsRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) 
                {
                    //ModelState.AddModelError("DeptId", "Please Select Department");
                    ModelState.AddModelError("NewKey", ex.InnerException.Message);
                }
            }
            ViewBag.DeptList = DeptRepository.GetAll();  // ==>
            return View("New", CrsFromReq);
        }


        // Course/Edit/id
        public IActionResult Edit(int id)
        {
            Course CrsFromDB = CrsRepository.GetByID(id);
            ViewBag.DeptList = DeptRepository.GetAll();
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
                Course CrsFromDB = new Course();
                // check modify based on comming data from request
                CrsFromDB.Id = CrsFromReq.Id;
                CrsFromDB.Name = CrsFromReq.Name;
                CrsFromDB.Degree = CrsFromReq.Degree;
                CrsFromDB.MinDegree = CrsFromReq.MinDegree;
                CrsFromDB.Hours = CrsFromReq.Hours;
                CrsFromDB.DeptId = CrsFromReq.DeptId;
                CrsRepository.Update(CrsFromDB);
                // save changes
                CrsRepository.Save();
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
