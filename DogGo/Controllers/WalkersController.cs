using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using DogGo.Models.ViewModels;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private IOwnerRepository _ownerRepo;
        private IWalksRepository _walksRepo;
        private INeighborhoodRepository _neighborhoodRepo;
        private IWalkerRepository _walkerRepo;

        public WalkersController(IWalkerRepository walkerRepository, IWalksRepository walksRepository, IOwnerRepository ownerRepository, INeighborhoodRepository neighborhoodRepository)
        {
            _walkerRepo = walkerRepository;
            _walksRepo = walksRepository;
            _ownerRepo = ownerRepository;
            _neighborhoodRepo = neighborhoodRepository;
        }

        public ActionResult Index()
        {
            List<Walker> walkers = _walkerRepo.GetAllWalkers();
            return View(walkers);
        }

        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walksRepo.GetAllWalks();
            List<Owner> owner = _ownerRepo.GetOwners();

            WalkerFormViewModel vm = new WalkerFormViewModel()
            {
                Walker = walker,
                Walks = walks,
                Owners = owner
            };

            if (walker == null)
            {
                return NotFound();
            }
            else
            {
                return View(vm);
            }
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
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();
            Walker walker = _walkerRepo.GetWalkerById(id);
            WalkerFormViewModel vm = new WalkerFormViewModel()
            {
                Walker = walker,
                Neighborhood = neighborhoods
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WalkerFormViewModel vm)
        {
            try
            {
                _walkerRepo.UpdateWalker(vm.Walker);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                vm.ErrorMessage = "There was an error editing the walker profile.";
                vm.Neighborhood = _neighborhoodRepo.GetAll();

                return View(vm);
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}