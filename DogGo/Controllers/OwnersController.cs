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

        public void AddOwner(Owner addOwner)
        {
        }

        public void UpdateOwner(Owner updateOwner)
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

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = owner,
                Dog = dogs,
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
                Neighborhood = neighborhoods
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
                viewModel.Neighborhood = _neighborhoodRepo.GetAll();
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();
            Owner owner = _ownerRepo.GetOwnerById(id);
            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = owner,
                Neighborhood = neighborhoods
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OwnerFormViewModel viewModel)
        {
            try
            {
                _ownerRepo.UpdateOwner(viewModel.Owner);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = "An error occured in your edit submission.";
                viewModel.Neighborhood = _neighborhoodRepo.GetAll();
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id, Owner ownerParam)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ownerParam);
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            Owner owner = _ownerRepo.GetOwnerByEmail(viewModel.Email);

            if (owner == null)
            {
                return Unauthorized();
            }

            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, owner.Id.ToString()),
        new Claim(ClaimTypes.Email, owner.Email),
        new Claim(ClaimTypes.Role, "DogOwner"),
    };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Dogs");
        }
    }
}