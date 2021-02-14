using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using DogGo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private IWalkerRepository _walkerRepo;
        private IWalksRepository _walksRepo;
        private IOwnerRepository _ownerRepo;
        private INeighborhoodRepository _neighborhoodRepo;

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
            Walker Walker = _walkerRepo.GetWalkerById(id);
            WalkerEditViewModel viewModel = new WalkerEditViewModel()
            {
                Walker = Walker,
                Neighborhood = neighborhoods
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WalkerEditViewModel viewModel)
        {
            try
            {
                _walkerRepo.UpdateWalker(viewModel.Walker);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = "There was an error editing the walker profile.";
                //viewModel.Neighborhood = _neighborhoodRepo.GetAll();

                return View(viewModel);
            }
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