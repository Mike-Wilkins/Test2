using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _db;

        public StudentController(IStudentRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var studentList = await _db.GetAllStudents();
            return View(studentList);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Create
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            await _db.Add(student);
            var studentList = await _db.GetAllStudents();

            return View("Index", studentList);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var student = _db.GetStudent(id);
            return View(student);
        }

        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _db.Delete(id);
            var studentList = await _db.GetAllStudents();
            return View("Index", studentList);
        }
    }
}
