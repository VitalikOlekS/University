using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManager.Models.EF
{
    [Table("tblUserAdditionalInfo")]
    public class UserAdditionalInfo
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Image { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }

    [Table("tblTeacherAdditionalInfo")]
    public class TeacherAdditionalInfo
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Skills { get; set; }
    }
}