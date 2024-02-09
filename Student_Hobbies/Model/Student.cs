using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Hobbies.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentGender { get; set; }
        public long StudentPhone { get; set; }
       
        public List<Hobbies> hobbies { get; set; }

    }
}
