using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Client.Models;
using Assignment3_Client.Persistence;

namespace Assignment3_Client.Data
{
    public class JsonData : IData
    {
        private readonly FileContext _fileContext;

        public JsonData()
        {
             _fileContext = new FileContext();
        }
        public Task<List<Adult>> GetAdults()
        {
            return Task.FromResult(_fileContext.Adults.ToList());
        }

        public Task<List<Family>> GetFamilies()
        {
            return Task.FromResult(_fileContext.Families.ToList());
        }

        public Task AddAdult(Adult adult)
        {
            if(IsIdLegal(adult.Id))
            {
                _fileContext.Adults.Add(adult);
                _fileContext.SaveChanges();
            }

            return Task.CompletedTask;
        }

        private bool IsIdLegal(int id)
        {
            foreach (Family family in GetFamilies().Result)
            {
                foreach (Adult adult in family.Adults)
                {
                    if (adult.Id == id)
                        return false;
                }
            }
            return true;
        }

        public void AddAdultToFamily(int id, Family fam)
        {
            Family family = GetFamily(fam.StreetName, fam.HouseNumber).Result;
            if(family.Adults.Count<2)
                family.Adults.Add(GetAdult(id).Result);
            _fileContext.SaveChanges();
        }

        public Task AddFamily(Family family)
        {
            if(GetFamily(family.StreetName,family.HouseNumber)==null)
            {
                _fileContext.Families.Add(family);
                _fileContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task AddChild(Child child, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Result.Children.Add(child);
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddPet(Pet pet, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Result.Pets.Add(pet);
            _fileContext.SaveChanges();
            return Task.CompletedTask;
            
        }
        
        public Task AddPetToChild(Pet pet, int childId, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Result.Children.First((child => child.Id==childId)).Pets.Add(pet);
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }
        
        public Task AddInterestToChild(Interest interest, int childId, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Result.Children.First((child => child.Id==childId)).Interests.Add(interest);
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAdult(Adult adult)
        {
            Adult adultToUpdate = GetAdult(adult.Id).Result;
            adultToUpdate.JobTitle = adult.JobTitle;
            adultToUpdate.Weight = adult.Weight;
            adultToUpdate.Height = adult.Height;
            adultToUpdate.HairColor = adult.HairColor;
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateFamily(Family family)
        {
            Family familyToUpdate = GetFamily(family.StreetName, family.HouseNumber).Result;
            familyToUpdate.Adults = family.Adults;
            familyToUpdate.Children = family.Children;
            familyToUpdate.Pets = family.Pets;
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveAdult(int adultId)
        {
            Adult adult = GetAdult(adultId).Result;
            GetAdults().Result.Remove(adult);
            _fileContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Adult> GetAdult(int id)
        {
            Adult adult = _fileContext.Adults.First(adult => adult.Id == id);
            return Task.FromResult(adult);
        }

        public Task<Family> GetFamily(string streetName, int houseNumber)
        {
            Family family;
            try
            {
                family=_fileContext.Families.First(family1 =>
                    family1.StreetName == streetName && family1.HouseNumber == houseNumber);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return Task.FromResult(family);
        }
        

        public Task<Family> GetFamilyFromAdult(int id)
        {
            foreach (Family xFamily in _fileContext.Families)
            {
                Adult[] adults = xFamily.Adults.ToArray();
                foreach (Adult adult in adults)
                {
                    if (adult.Id == id)
                        return Task.FromResult(xFamily);
                }
            }

            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}