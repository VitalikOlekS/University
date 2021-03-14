using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityManager.Models
{
    public class StudentGroupViewModel
    {
        public string Id { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }
        public string Student { get; set; }

    }
    public class CreateStudentGroupViewModel
    {

        [Required]
        [DisplayName("Group")]
        public string GroupId { get; set; }
        public List<SelectListItem> Groups { get; set; }

        [Required]
        [DisplayName("Student")]
        public string StudentId { get; set; }
        public List<SelectListItem> Studetnts { get; set; }
        public CreateStudentGroupViewModel()
        {
            Groups = new List<SelectListItem>();
            Studetnts = new List<SelectListItem>();
        }
    }
}