
using AutoMapper;
using HR_Management_System.Contracts;
using HR_Management_System.Data;
using HR_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IDepartmentRepository _departmentrepo;
        private readonly IQualificationRepository _qualificationrepo;
        private readonly IRelationshipTypeRepository _relationshiptyperepo;
        private readonly IEmployeeRepository _employeerepo;
        private readonly IMapper _mapper;

        public EmployeeController(
            IDepartmentRepository departmentrepo,
            IQualificationRepository qualificationrepo,
            IRelationshipTypeRepository relationshiptyperepo,
            IEmployeeRepository employeerepo, 
            IMapper mapper
            )
        {
            _departmentrepo = departmentrepo;
            _qualificationrepo = qualificationrepo;
            _relationshiptyperepo = relationshiptyperepo;
            _employeerepo = employeerepo;
            _mapper = mapper;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var Employees = _employeerepo.FindAll().ToList();
            var model = _mapper.Map<List<Employee>, List<EmployeeVM>>(Employees);
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_employeerepo.isExists(id))
            {
                return NotFound();
            }
            var Employees = _employeerepo.FindById(id);
            var model = _mapper.Map<EmployeeVM>(Employees);
            return View(model);
        }
        

// GET: EmployeeController/Create
public ActionResult Create()
        {
            var department = _departmentrepo.FindAll();           
            var departmentItems = department.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var relationshiptype = _relationshiptyperepo.FindAll();
            var relationshiptypeItems = relationshiptype.Select(q => new SelectListItem {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new EmployeeVM
            {
                Department = departmentItems,
                RelationshipType = relationshiptypeItems
            };
            return View(model);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            {
                if (!_employeerepo.isExists(id))
                {
                    return NotFound();
                }
                var employee = _employeerepo.FindById(id);
                var model = _mapper.Map<EmployeeVM>(employee);
                return View(model);
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var employee = _mapper.Map<Employee>(model);
                var isSuccess = _employeerepo.Update(employee);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeerepo.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var isSuccess = _employeerepo.Delete(employee);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeVM model)
        {
            try
            {
                var employee = _employeerepo.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                var isSuccess = _employeerepo.Delete(employee);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
