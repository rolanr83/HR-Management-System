using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _db;

        public EducationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Education entity)
        {
            _db.Educations.Add(entity);
            return Save();
        }

        public bool Delete(Education entity)
        {
            _db.Educations.Remove(entity);
            return Save();
        }

        public ICollection<Education> FindAll()
        {
            return _db.Educations.ToList();
        }

        public Education FindById(int id)
        {
            return _db.Educations.Find(id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Education entity)
        {
            _db.Educations.Update(entity);
            return Save();
        }
    }
}
