using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string TRN { get; set; }
        [Required]
        public string NIS { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }
        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Parish { get; set; }
        [Required]
        public string Country { get; set; }
        public string HomeNumber { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        //public string EmployeementStatus { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Post { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EducationVM Education { get; set; }
        public int EducationId { get; set; }
        public IEnumerable<SelectListItem> EducationVM { get; set; }

        public PositionVM Position { get; set; }
        public int PositionId { get; set; }
        public IEnumerable<SelectListItem> PositionVM { get; set; }

        public EmergencyContactVM EmergencyContact { get; set; }
        public int EmergencyContactId { get; set; }
        public IEnumerable<SelectListItem> EmergencyContactVM { get; set; }
    }
}
