using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Delete(int id)
        {
            var student = await _context.Students.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var studentList = await _context.Students.OrderBy(m => m.Id).ToListAsync();
            return studentList;
        }

        public Student GetStudent(int id)
        {
            var student = _context.Students.Where(m => m.Id == id).FirstOrDefault();
            return student;
        }
    }
}
