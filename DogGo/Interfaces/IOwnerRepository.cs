using System.Collections.Generic;

namespace DogGo.Models
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner GetOwnerById(int id);
    }
}