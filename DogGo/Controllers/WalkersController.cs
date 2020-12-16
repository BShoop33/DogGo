using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using DogGo.Models.ViewModels;

namespace DogGo.Controllers
{
    public class WalkersController : Controller, IWalkerRepository
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalksRepository _walksRepo;
        private readonly IOwnerRepository _ownerRepo;

        public WalkersController(IWalkerRepository walkerRepository, IWalksRepository walksRepository, IOwnerRepository ownerRepository)
        {
            _walkerRepo = walkerRepository;
            _walksRepo = walksRepository;
            _ownerRepo = ownerRepository;
        }

       

        public List<Walker> GetAllWalkers()
        {
            return _walkerRepo.GetAllWalkers();
        }

        public Walker GetWalkerById(int id)
        {
            return _walkerRepo.GetWalkerById(id);
        }

        // GET: WalkersController
        public ActionResult Index()
        {
            List<Walker> walkers = _walkerRepo.GetAllWalkers();
            return View(walkers);
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walksRepo.GetAllWalks();
            Owner owner = _ownerRepo.GetOwnerById(id);

            WalkerFormViewModel vm = new WalkerFormViewModel()
            {
                Owner = owner,
                Walker = walker,
                Walks = walks
            };

            if (walker == null)
            {
                return NotFound();
            }
            else
            {

                return View(vm);
            }


            //if (walker == null)
            //{
            //    return NotFound();
            //}

            //return View(walker);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
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

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
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

        public List<Walker> GetWalkersInNeighborhood(int neighborhoodId)
        {
            throw new NotImplementedException();
        }
    }
}