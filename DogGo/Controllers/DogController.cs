using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace DogGo.Controllers
{
    //Creates the DogController class, inherits the Controller class, and interfaces the IDogRepository interface.
    public class DogController : Controller, IDogRepository
    {
        //Declares a private _dogRepo field of type IDogRespository.
        private IDogRepository _dogRepo;

        //Creates a DogController constructor and performs a Dependency Injection that makes an instance of IDogRepository named dogRepository.
        //Then stores that instance of IDogRepository in the _dogRepo field.
        public DogController(IDogRepository dogRepository)
        {
            _dogRepo = dogRepository;
        }

        //Implements the GetDogs() method that is defined in DogRepository.cs and interfaced through IDogRepository.cs.
        //The GetDogs() method performs a sequel query that returns a list of all Dog objects in the dbo.Dog database.
        public List<Dog> GetDogs()
        {
            return _dogRepo.GetDogs();
        }

        //Implements the GetDogsById() method that is defined in DogRepository.cs and interfaced through IDogRepository.cs.
        /*The GetDogsById() method performs a sequel query that returns a list of all Dog objects in the dbo.Dog database that match the given 
          Id variable. That Id variable is always assigned by the URL route parameter in this project.
        */
        public Dog GetDogById(int id)
        {
            return _dogRepo.GetDogById(id);
        }

        //Implements the AddDogs() method that is defined in DogRepository.cs and interfaced through IDogRepository.cs.
        //The AddDogs() method performs a sequel query that inserts a new Dog object into the dbo.Dog database.
        public void AddDog(Dog dog)
        {
        }

        //Implements the UpdateDogs() method that is defined in DogRepository.cs and interfaced through IDogRepository.cs.
        //The UpdateDogs() method performs a sequel query that inserts user-provided changes to an existing Dog object record in the dbo.Dog database.
        public void UpdateDog(Dog dog)
        {
        }

        //Implements the DeleteDogs() method that is defined in DogRepository.cs and interfaced through IDogRepository.cs.
        //The DeleteDogs() method performs a sequel query that removes an entire Dog object record from the dbo.Dog database.
        public void DeleteDog(int dogId)
        {
        }

        /*Performs the default ActionResult implementation of the Index() method. That method creates a new list of Dog objects called 'dogs' and 
          populates it with the results returned by the GetDogs() method. Then invokes the View() method which passes the dogs object to the 
          Index.cshtml View.
        */
        public ActionResult Index()
        {
            List<Dog> dogs = _dogRepo.GetDogs();
            return View(dogs);
        }

        /*Performs the default ActionResult implementation of the Details() method. That method creates a single Dog object called 'dog' and
          populates it with the results returned by the GetDogById() method. Then evaluates whether the dog object is null value; if null then 
          invokes the NotFound() method, if not null then invokes the View method which passes the dog object to the Details.cshtml View for Dog.
        */
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        //Performs the first default ActionResult implementation of the Create() method. This first implementation invokes the View method.
        //That method causes Create.cshtml to render as a blank form.
        public ActionResult Create()
        {
            return View();
        }

        /*Performs the second default ActionResult implementation of the Create() method. This second implementation performs a try/catch operation.
          That operation tries to insert a new Dog object to the dbo.Dog database based on the web page's form inputs and then render the Index.cshtml 
          View. If any errors occur, the catch statement instead renders the Create.cshtml View along with the user-provided form inputs.
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                _dogRepo.AddDog(dog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        /*Performs the first default ActionResult implementation of the Edit() method. This first implementation creates a new Dog object
          called 'dog' and populates it with the returned results of the GetDogById method. Then it evaluates whether that dog object's value
          is null; if the value is null, then the NotFound() method is invoked. If hte value is not null then the View() method is invoked which
          populates the Edit.cshtml View with the returned dog object data.
        */
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        /*Performs the second default ActionResult implementation of the Edit() method. This second implementation performs a try/catch operation.
          That operation tries to update an Dog object in the dbo.Dog database with user inputs from the web page's form inputs and then render 
          the Index.cshtml View. If any errors occur, the catch statement instead renders the Create.cshtml View along with the user-provided form 
          inputs
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRepo.UpdateDog(dog);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        /*Performs the default ActionResult implementation of the Delete() method. That method performs a try/catch operation. That operation tries 
          to invoke the DeleteDog() method to remove an existing Dog object from the dbo.Dog database and then render the Index.cshtml View. If any 
          errors occur, the catch statement instead renders the View of the current page along with the Dog object data.
        */
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.DeleteDog(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
    }
}