using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManager.Models.EF
{
    [Table("tb.Groups")]
    public class Group
    {
        public Group()
        {
            this.GroupRequests = new HashSet<GroupRequest>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<GroupRequest> GroupRequests { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string EducationStartDate { get; set; }
    }
}