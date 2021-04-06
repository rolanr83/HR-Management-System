using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class EmergencyContactVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        
        public RelationshipTypeVM RelationshipType { get; set; }
        public int RelationshipTypeId { get; set; }

        public IEnumerable<SelectListItem> RelationshipTypes { get; set; }
    }
}
