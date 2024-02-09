using Microsoft.EntityFrameworkCore;
using Student_Hobbies.Data;
using Student_Hobbies.Model;


namespace Student_Hobbies.Repository
{
    public class HobbiesRepository : IHobbiesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentRepository _studentRepository;
        public HobbiesRepository(ApplicationDbContext context,StudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }
        
        public IEnumerable<ReturnModel> GetAllHobbies()
        {
            List<Hobbies> hobbies = _context.hobbies.ToList();

            HashSet<int> seenIds = new HashSet<int>(); // Keep track of seen StudentIds
            List<ReturnModel> returnModels = new List<ReturnModel>();

            foreach (Hobbies hobbies1 in hobbies)
            {
                int id = hobbies1.StudentId;

                // If we haven't seen this StudentId before, add it to the list
                if (!seenIds.Contains(id))
                {
                    ReturnModel returnModel = new ReturnModel();
                    Student student = _studentRepository.GetStudentById(hobbies1.StudentId);

                    returnModel.StudentName = student.StudentName;
                    returnModel.hobbies = student.hobbies;

                    returnModels.Add(returnModel);
                    seenIds.Add(id); // Add the id to the HashSet
                }
            }

            return returnModels;


        }

        public Hobbies GetHobbyById(int id)
        {
            return _context.hobbies.Find(id);
        }

        public void AddHobby(Hobbies hobby)
        {
            _context.hobbies.Add(hobby);
            _context.SaveChanges();
        }

        public void UpdateHobby(Hobbies hobby)
        {
            _context.Entry(hobby).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHobby(int id)
        {
            var hobby = _context.hobbies.Find(id);
            _context.hobbies.Remove(hobby);
            _context.SaveChanges();
        }
    }
}
