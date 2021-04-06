using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Department entity)
        {
            _db.Departments.Add(entity);
            return Save();
        }

        public bool Delete(Department entity)
        {
            _db.Departments.Remove(entity);
            return Save();
        }

        public ICollection<Department> FindAll()
        {
            return _db.Departments.ToList();
        }

        public Department FindById(int id)
        {
            return _db.Departments.Find(id);
        }

        public ICollection<Department> GetEmployeesByDepatrtment(int Id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exist = _db.Departments.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes =_db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Department entity)
        {
            _db.Departments.Update(entity);
            return Save();
        }
    }
}
