using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class TraineeController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var results = context.CrsResults
                .Include(r => r.Trainee)
                .Include(r => r.Crs)
                .Select(r => new TraineeCourseResult
                {
                    TraineeId = r.Trainee.Id,
                    TraineeName = r.Trainee.Name,
                    CourseName = r.Crs.Name,
                    Degree = r.Degree,
                    MinDegree = r.Crs.MinDegree
                }).ToList();

            return View(results);
        }



        public IActionResult Details(int id)
        {
            var trainee = context.Trainees
                .Include(t => t.Dept)
                .Include(t => t.CrsResults)
                    .ThenInclude(r => r.Crs)
                .FirstOrDefault(t => t.Id == id);

            if (trainee == null)
                return NotFound();

            return View(trainee);
        }




        public IActionResult GetResult(int traineeId, int courseId)
        {
            var result = context.CrsResults
                                .Include(r => r.Trainee)
                                .Include(r => r.Crs)
                                .FirstOrDefault(r => r.TraineeId == traineeId && r.CrsId == courseId);

            if (result == null)
            {
                return NotFound("Result not found for this trainee and course.");
            }

            bool isPassed = result.Degree >= result.Crs.MinDegree;

            var response = new
            {
                TraineeName = result.Trainee.Name,
                CourseName = result.Crs.Name,
                Degree = result.Degree,
                MinDegree = result.Crs.MinDegree,
                Status = isPassed ? "Success ✔" : "Failed ❌",
                
                ImgUrl = result.Trainee.img,
                DeptName = result.Trainee.Dept.Name,
                Address = result.Trainee.Addres
            };

            return Json(response);
        }



        public IActionResult New()
        {
            var viewModel = new AddResultViewModel
            {
                TraineeList = context.Trainees.ToList(),
                CourseList = context.Courses.ToList()
            };

            return View("New", viewModel);
        }


        [HttpPost]
        public IActionResult SaveNew(AddResultViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                var result = new CrsResult
                {
                    TraineeId = model.TraineeId,
                    CrsId = model.CrsId,
                    Degree = model.Degree
                };

                context.CrsResults.Add(result);
                context.SaveChanges();

                return RedirectToAction("Index");
            //}

            model.TraineeList = context.Trainees.ToList();
            model.CourseList = context.Courses.ToList();

            return View("New", model);
        }


    }
}
