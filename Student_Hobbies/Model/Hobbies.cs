using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Hobbies.Model
{
    public class Hobbies
    {
        [Key]
        public int Id { get; set; }
        public string Hobby   { get; set; }
        
        [ForeignKey("StudId")]
      // public virtual Student student { get; set; }
        public int StudentId { get; set; }
 
    }
}
