using Microsoft.EntityFrameworkCore;
using Student_Hobbies.Data;
using Student_Hobbies.Model;

namespace Student_Hobbies.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.students.Include(s=>s.hobbies).ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.students.Include(s => s.hobbies).FirstOrDefault(s => s.StudentId == id);
        }

        public void AddStudent(Student student)
        {
            
            _context.students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.students.Find(id);
            _context.students.Remove(student);
            _context.SaveChanges();
        }
    }

}
