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
    public class QualificationController : Controller
    {
        private readonly IQualificationRepository _repo;
        private readonly IMapper _mapper;

        public QualificationController(IQualificationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: QualificationController
        public ActionResult Index()
        {
            var Qualifications = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Qualification>, List<QualificationVM>>(Qualifications);
            return View(model);
        }

        // GET: QualificationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QualificationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QualificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QualificationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var qualification = _mapper.Map<Qualification>(model);
                qualification.DateCompleted = DateTime.Now; // this need to be change so the user can select the date they completed the degree

                var isSuccess = _repo.Create(qualification);
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

        // GET: QualificationController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var qualification = _repo.FindById(id);
            var model = _mapper.Map<QualificationVM>(qualification);
            return View(model);
        }

        // POST: QualificationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QualificationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var qualification = _mapper.Map<Qualification>(model);
                var isSuccess = _repo.Update(qualification);
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

        // GET: QualificationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QualificationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
