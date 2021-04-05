using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Data
{
    public class EmergencyContact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        [ForeignKey("RelationshipTypeId")]
        public RelationshipType RelationshipType { get; set; }
        public int RelationshipTypeId { get; set; }
    }
}
