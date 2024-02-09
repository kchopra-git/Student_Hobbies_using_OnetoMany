using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentHobbies.Models
{
    public class Hobbies
    {
        [Key]
        public int Id { get; set; }
        public string Hobby   { get; set; }
        
        [ForeignKey("StudId")]
      // public virtual Student student { get; set; }
        public int StudentId { get; set; }
        //[NotMapped]
        //public String? StudentName { get; set; }
    }
}
