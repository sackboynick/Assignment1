using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment3_Client.Models;

namespace Assignment3_Client.Data
{
    public interface IData 
    {
        Task<List<Adult>> GetAdults();
        Task<List<Family>> GetFamilies();
        Task AddAdult(Adult adult);
        void AddAdultToFamily(int id, Family family);
        Task AddFamily(Family family);
        Task AddChild(Child child, Family family);
        Task AddPet(Pet pet, Family family);
        Task AddPetToChild(Pet pet, int childId, Family family);
        Task AddInterestToChild(Interest interest, int childId, Family family);
        Task UpdateAdult(Adult adult);
        Task UpdateFamily(Family family);

        Task RemoveAdult(int adultId);
        
        Task<Adult> GetAdult(int id);
        Task<Family> GetFamily(string streetName, int houseNumber);
        Task<Family> GetFamilyFromAdult(int id);
        
        
        

    }
}