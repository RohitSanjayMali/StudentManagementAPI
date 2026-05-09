using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync() =>
            await _context.students.ToListAsync();
        

        public async Task<Student> GetByStudentIdAsync(int id) =>
            await _context.students.FindAsync(id);
        
        public async Task AddAsync(Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            var exiting = await _context.students.FindAsync(student.Id);

            if (exiting == null)
                throw new Exception("Student is not found");
            exiting.Name = student.Name;
            exiting.Email = student.Email;
            exiting.Age = student.Age;
            exiting.Course = student.Course;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
                throw new Exception($"Student with ID {id} not found");

            _context.students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
