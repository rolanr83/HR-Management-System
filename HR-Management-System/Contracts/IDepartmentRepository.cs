using HR_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Contracts
{
    public interface IDepartmentRepository :IRepositoryBase<Department>
    {
        ICollection<Department> GetEmployeesByDepatrtment(int Id);
    }
}
