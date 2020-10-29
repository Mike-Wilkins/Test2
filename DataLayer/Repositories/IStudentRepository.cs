using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> Add(Student student);
        Task<Student> Delete(int id);
        Student GetStudent(int id);
        Task<IEnumerable<Student>> GetAllStudents();

    }
}
