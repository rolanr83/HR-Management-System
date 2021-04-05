using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class RelationshipRepository : IRelationshipTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public RelationshipRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(RelationshipType entity)
        {
            _db.RelationshipTypes.Add(entity);
            return Save();
        }

        public bool Delete(RelationshipType entity)
        {
            _db.RelationshipTypes.Remove(entity);
            return Save();
        }

        public ICollection<RelationshipType> FindAll()
        {
            return _db.RelationshipTypes.ToList();
        }

        public RelationshipType FindById(int id)
        {
            return _db.RelationshipTypes.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(RelationshipType entity)
        {
            _db.RelationshipTypes.Update(entity);
            return Save();
        }
    }
}
