using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _db;

        public PositionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Position entity)
        {
            _db.Positions.Add(entity);
            return Save();
        }

        public bool Delete(Position entity)
        {
            _db.Positions.Remove(entity);
            return Save();
        }

        public ICollection<Position> FindAll()
        {
            return _db.Positions.ToList();
        }

        public Position FindById(int id)
        {
            return _db.Positions.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Position entity)
        {
            _db.Positions.Update(entity);
            return Save();
        }
    }
}
