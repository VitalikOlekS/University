using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManager.Models.EF
{
    [Table("tb.RequestToGroup")]
    public class GroupRequest
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}