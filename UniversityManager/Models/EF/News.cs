using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManager.Models.EF
{
    [Table("tb.News")]
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RealeseDate { get; set; }
    }
}