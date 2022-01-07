using Assignment3_WebAPI.Models;

namespace Assignment3_WebAPI.Data
{
    public interface IData 
    {
        Adult[] GetAdults();
        Family[] GetFamilies();
        void AddAdult(Adult adult);
        void AddAdultToFamily(int id, Family family);
        void AddFamily(Family family);
        void AddChild(Child child, Family family);
        void AddPet(Pet pet, Family family);
        void AddPetToChild(Pet pet, int childId,Family family);
        void AddInterestToChild(Interest interest, int childId, Family family);
        void UpdateAdult(Adult adult);
        void UpdateFamily(Family family);

        void RemoveAdult(int adultId);
        
        Adult GetAdult(int id);
        Family GetFamily(string streetName, int houseNumber);
        Family GetFamilyFromAdult(int id);
        
        
        

    }
}