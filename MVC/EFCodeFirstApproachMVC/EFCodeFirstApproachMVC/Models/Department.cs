using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApproachMVC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Department Head")]
        public string DepartmentHead { get; set; }
        [Required]
        public double Budget { get; set; }
        [Required]
        [Display(Name = "Creation Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}