using DataLayer.Models;
using DataLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private IApplicationDbContext _context;

        public StudentController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var studentList = _context.Students.OrderBy(m => m.Id).ToList();
            return studentList;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.Students.Find(id);
            return student;
        }

        [HttpPost("create")]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Student> UpdateStudent(int id, Student studentUpdate)
        {
            if(id != studentUpdate.Id)
            {
                return BadRequest();
            }
            var student = _context.Students.Attach(studentUpdate);
            student.State = EntityState.Modified;
            _context.SaveChanges();
            return studentUpdate;
        }


        
    }
}
