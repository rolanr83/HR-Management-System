using AutoMapper;
using HR_Management_System.Contracts;
using HR_Management_System.Data;
using HR_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var Employees = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Employee>, List<EmployeeVM>>(Employees);
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var Employees = _repo.FindById(id);
            var model = _mapper.Map<EmployeeVM>(Employees);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var employee = _mapper.Map<Employee>(model);
                var isSuccess = _repo.Create(employee);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            {
                if (!_repo.isExists(id))
                {
                    return NotFound();
                }
                var employee = _repo.FindById(id);
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
                var isSuccess = _repo.Update(employee);
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
            var employee = _repo.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(employee);
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
                var employee = _repo.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(employee);
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
