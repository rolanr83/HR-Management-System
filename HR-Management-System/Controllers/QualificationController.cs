﻿using AutoMapper;
using HR_Management_System.Contracts;
using HR_Management_System.Data;
using HR_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            var Qualification = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Qualification>, List<QualificationVM>>(Qualification);
            return View(model);
        }

        // GET: QualificationController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var Qualification = _repo.FindById(id);
            var model = _mapper.Map<QualificationVM>(Qualification);
            return View(model);
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
            var qualification = _repo.FindById(id);
            if (qualification == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(qualification);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: QualificationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, QualificationVM model)
        {
            try
            {
                var qualification = _repo.FindById(id);
                if (qualification == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(qualification);
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
