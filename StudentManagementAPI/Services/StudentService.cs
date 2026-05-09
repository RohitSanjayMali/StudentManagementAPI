using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _repo.GetAllStudentsAsync();
        }

        public async Task<Student?> GetByStudentIdAsync(int id)
        {
            var student = await _repo.GetByStudentIdAsync(id);

            if (student == null)
                _logger.LogWarning("Student with ID {Id} not found", id);

            return student;
        }

        public async Task AddAsync(Student student)
        {
            _logger.LogInformation("Adding student with Name: {Name}", student.Name);
            await _repo.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _logger.LogInformation("Updating student {Id}", student.Id);
            await _repo.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _repo.GetByStudentIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Delete failed: Student with ID {Id} not found", id);
                return;
            }

            _logger.LogInformation("Deleting student with ID {Id}", id); // BUG FIX: log after existence check
            await _repo.DeleteAsync(id);
        }
    }
}
