using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _ownerRepo;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepo.GetOwners();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepo.GetOwnerById(id);
        }

        public Owner GetOwnerByEmail(string email)
        {
            return _ownerRepo.GetOwnerByEmail(email);
        }

        public void AddOwner(Owner owner)
        {
        }

        public void UpdateOwner(Owner owner)
        {
        }






        public void DeleteOwner(int ownerId)
        {
        }





        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetOwners();
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
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(owner);
            }
        }

        public ActionResult Delete(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            return View(owner);
        }

    }
}