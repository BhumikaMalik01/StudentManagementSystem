using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementDomainLayer.Models
{
    [Keyless]
    public class StudentMarks
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public int StuMarks { get; set; }
        public int StuSem { get; set; }
    }
}
