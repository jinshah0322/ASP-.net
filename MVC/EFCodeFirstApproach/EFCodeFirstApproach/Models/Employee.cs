using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstApproach.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+(?:[0-9] ?){6,14}[0-9]$", ErrorMessage = "Invalid Mobile Number")]
        public string Mobile {  get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DOB { get; set;}
        [Required]
        public string InterestedTechnology { get; set; }
    }
}