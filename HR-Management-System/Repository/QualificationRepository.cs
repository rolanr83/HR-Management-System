﻿using HR_Management_System.Contracts;
using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Repository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ApplicationDbContext _db;

        public QualificationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Qualification entity)
        {
            _db.Qualifications.Add(entity);
            return Save();
        }

        public bool Delete(Qualification entity)
        {
            _db.Qualifications.Remove(entity);
            return Save();
        }

        public ICollection<Qualification> FindAll()
        {
            return _db.Qualifications.ToList();
        }

        public Qualification FindById(int id)
        {
            return _db.Qualifications.Find();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Qualification entity)
        {
            _db.Qualifications.Update(entity);
            return Save();
        }
    }
}
