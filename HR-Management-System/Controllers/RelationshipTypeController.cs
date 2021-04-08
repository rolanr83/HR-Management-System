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
    public class RelationshipTypeController : Controller
    {
        private readonly IRelationshipTypeRepository _repo;
        private readonly IMapper _mapper;

        public RelationshipTypeController(IRelationshipTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: RelationshipTypeController
        public ActionResult Index()
        {
            var RelationshipTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<RelationshipType>, List<RelationshipTypeVM>>(RelationshipTypes);
            return View(model);
        }

        // GET: RelationshipTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var relationshipTypes = _repo.FindById(id);
            var model = _mapper.Map<RelationshipTypeVM>(relationshipTypes);
            return View(model);
        }

        // GET: RelationshipTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelationshipTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RelationshipTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var relationshipType = _mapper.Map<RelationshipType>(model);
                var isSuccess = _repo.Create(relationshipType);
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

        // GET: RelationshipTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var relationshipType = _repo.FindById(id);
            var model = _mapper.Map<RelationshipTypeVM>(relationshipType);
            return View(model);
        }

        // POST: RelationshipTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RelationshipTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var relationshipType = _mapper.Map<RelationshipType>(model);
                var isSuccess = _repo.Update(relationshipType);
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
                return View();
            }
        }

        // GET: RelationshipTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var relationshipType = _repo.FindById(id);
            if (relationshipType == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(relationshipType);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: RelationshipTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RelationshipTypeVM model)
        {
            try
            {
                var relationshipType = _repo.FindById(id);
                if (relationshipType == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(relationshipType);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
