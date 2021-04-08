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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var Departments = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Department>, List<DepartmentVM>>(Departments);
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var Departments = _repo.FindById(id);
            var model = _mapper.Map<DepartmentVM>(Departments);
            return View(model);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var department = _mapper.Map<Department>(model);
                var isSuccess = _repo.Create(department);
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var department = _repo.FindById(id);
            var model = _mapper.Map<DepartmentVM>(department);
            return View(model);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var department = _mapper.Map<Department>(model);
                var isSuccess = _repo.Update(department);
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _repo.FindById(id);
            if (department == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(department);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentVM model)
        {
            try
            {
                var department = _repo.FindById(id);
                if (department == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(department);
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
