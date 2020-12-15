using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetDogs();

        Dog GetDogById(int id);

        void AddDog(Dog dog);

        void UpdateDog(Dog dog);

        void DeleteDog(int dogId);
    }
}