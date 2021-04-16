using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int TRN { get; set; }
        public string NIS { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Parish { get; set; }
        public string Country { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeementStatus { get; set; }
        public string Post { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string Education { get; set; }
        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; }
        public int QualificationId { get; set; }
        public string Emergency { get; set; }
        [ForeignKey("EmergencyContactId")]
        public EmergencyContact EmergencyContact { get; set; }
        public int EmergencyContactId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
                

    }
}
