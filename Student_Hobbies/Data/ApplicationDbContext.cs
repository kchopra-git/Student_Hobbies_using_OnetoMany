using Microsoft.EntityFrameworkCore;
using Student_Hobbies.Model;

namespace Student_Hobbies.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
      public  DbSet<Student> students {  get; set; }
      public  DbSet<Hobbies> hobbies { get; set;}
     // public DbSet<Student_HobbiesMapping_Model> student_HobbiesMapping_Models { get; set; }
    }
}
