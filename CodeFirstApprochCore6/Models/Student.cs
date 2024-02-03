using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApprochCore6.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column("StudentName",TypeName ="varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column("StudentGender", TypeName = "varchar(20)")]
        public string Gender { get; set; }

        [Required]
        public int? Age { get; set; }


    }
}
