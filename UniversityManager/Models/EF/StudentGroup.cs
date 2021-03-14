using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManager.Models.EF
{
    [Table("tblStudentGroup")]
    public class StudentGroup
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}