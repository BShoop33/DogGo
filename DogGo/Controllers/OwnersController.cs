using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using DogGo.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private IOwnerRepository _ownerRepo;
        private IDogRepository _dogRepo;
        private IWalkerRepository _walkerRepo;
        private INeighborhoodRepository _neighborhoodRepo;

        public OwnersController(IOwnerRepository ownerRepo, IDogRepository dogRepo, IWalkerRepository walkerRepo, INeighborhoodRepository neighborhoodRepo)
        {
            _ownerRepo = ownerRepo;
            _dogRepo = dogRepo;
            _walkerRepo = walkerRepo;
            _neighborhoodRepo = neighborhoodRepo;
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
            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(owner.Id);
            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);

            ProfileViewModel vm = new ProfileViewModel()
            {
                Owner = owner,
                Dogs = dogs,
                Walkers = walkers
            };

            return View(vm);
        }

        public ActionResult Create()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = new Owner(),
                Neighborhoods = neighborhoods
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OwnerFormViewModel viewModel)
        {
            try
            {
                _ownerRepo.AddOwner(viewModel.Owner);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = "Something went wrong";
                viewModel.NeighborhoodOptions = _neighborhoodRepo.GetAll();
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = owner,
                Neighborhoods = neighborhoods
            };

            if (owner == null)
            {
                return NotFound();
            }
            else
            { 

            return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }









    }
}