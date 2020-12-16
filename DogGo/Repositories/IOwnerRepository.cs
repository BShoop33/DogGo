using DogGo.Models;
using DogGo.Models.ViewModels;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetOwners();

        Owner GetOwnerById(int id);

        Owner GetOwnerByEmail(string email);

        void AddOwner(Owner owner);

        void DeleteOwner(int ownerId);
        
        void UpdateOwner(Owner owner);
    }
}