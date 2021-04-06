using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly ApplicationDbContext _db;

        public EmergencyContactRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Data.EmergencyContact entity)
        {
            _db.EmergencyContacts.Add(entity);
            return Save();
        }

        public bool Delete(Data.EmergencyContact entity)
        {
            _db.EmergencyContacts.Remove(entity);
            return Save();
        }

        public ICollection<Data.EmergencyContact> FindAll()
        {
            return _db.EmergencyContacts.ToList();
        }

        public Data.EmergencyContact FindById(int id)
        {
            return _db.EmergencyContacts.Find(id);
        }

        public bool isExists(int id)
        {
            var exist = _db.EmergencyContacts.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Data.EmergencyContact entity)
        {
            _db.EmergencyContacts.Update(entity);
            return Save();
        }
    }
}
