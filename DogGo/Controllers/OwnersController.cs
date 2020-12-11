using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DogGo.Controllers
{


    public class OwnersController : Controller, IOwnerRepository
    {
        private readonly IOwnerRepository _ownerRepo;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.GetAllOwners();
        }
        public Owner GetOwnerById(int id)
        {
            return _ownerRepo.GetOwnerById(id);
        }

        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();
            return View(owners);
        }

        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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