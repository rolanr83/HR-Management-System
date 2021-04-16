using AutoMapper;
using HR_Management_System.Data;
using HR_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Mappings
{
    public class Maps : Profile   
    {
        public Maps()
        {
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Qualification, QualificationVM>().ReverseMap();
            CreateMap<RelationshipType, RelationshipTypeVM>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
