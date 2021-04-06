using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HR_Management_System.Models;

namespace HR_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<HR_Management_System.Models.DepartmentVM> DepartmentVM { get; set; }
        public DbSet<HR_Management_System.Models.RelationshipTypeVM> RelationshipTypeVM { get; set; }
        public DbSet<HR_Management_System.Models.QualificationVM> QualificationVM { get; set; }
    }
}
