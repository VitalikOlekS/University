using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManager.Models
{
    public class GroupRequestViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }
    }

    public class CreateGroupRequestViewModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string GroupId { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public CreateGroupRequestViewModel()
        {
            Groups = new List<SelectListItem>();
        }
    }

    

}