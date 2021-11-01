using System;
using System.Linq;
using Assignment2_WebAPI.Models;
using Assignment2_WebAPI.Persistence;

namespace Assignment2_WebAPI.Data
{
    public class JsonData : IData
    {
        private readonly FileContext _fileContext;

        public JsonData()
        {
             _fileContext = new FileContext();
        }
        public Adult[] GetAdults()
        {
            return _fileContext.Adults.ToArray();
        }

        public Family[] GetFamilies()
        {
            return _fileContext.Families.ToArray();
        }

        public void AddAdult(Adult adult)
        {
            if(IsIdLegal(adult.Id))
            {
                _fileContext.Adults.Add(adult);
                _fileContext.SaveChanges();
            }
        }

        private bool IsIdLegal(int id)
        {
            foreach (Family family in GetFamilies())
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
            Family family = GetFamily(fam.StreetName, fam.HouseNumber);
            if(family.Adults.Count<2)
                family.Adults.Add(GetAdult(id));
            _fileContext.SaveChanges();
        }

        public void AddFamily(Family family)
        {
            if(GetFamily(family.StreetName,family.HouseNumber)==null)
            {
                _fileContext.Families.Add(family);
                _fileContext.SaveChanges();
            }
        }

        public void AddChild(Child child, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Children.Add(child);
            _fileContext.SaveChanges();
        }

        public void AddPet(Pet pet, Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Pets.Add(pet);
            _fileContext.SaveChanges();
        }
        
        public void AddPetToChild(Pet pet, int childId,Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Children.First((child => child.Id==childId)).Pets.Add(pet);
            _fileContext.SaveChanges();
        }
        
        public void AddInterestToChild(Interest interest, int childId,Family family)
        {
            GetFamily(family.StreetName,family.HouseNumber).Children.First((child => child.Id==childId)).Interests.Add(interest);
            _fileContext.SaveChanges();
        }

        public void UpdateAdult(Adult adult)
        {
            Adult adultToUpdate = GetAdult(adult.Id);
            adultToUpdate.JobTitle = adult.JobTitle;
            adultToUpdate.Weight = adult.Weight;
            adultToUpdate.Height = adult.Height;
            adultToUpdate.HairColor = adult.HairColor;
            adultToUpdate.Age = adult.Age;
            adultToUpdate.EyeColor = adult.EyeColor;
            _fileContext.SaveChanges();
        }

        public void UpdateFamily(Family family)
        {
            Family familyToUpdate = GetFamily(family.StreetName, family.HouseNumber);
            familyToUpdate.Adults = family.Adults;
            familyToUpdate.Children = family.Children;
            familyToUpdate.Pets = family.Pets;
            _fileContext.SaveChanges();
        }

        public void RemoveAdult(int adultId)
        {
            Adult adult = GetAdult(adultId);
            GetAdults().ToList().Remove(adult);
            _fileContext.SaveChanges();
        }

        public Adult GetAdult(int id)
        {
            Adult adult = _fileContext.Adults.First(adult => adult.Id == id);
            return adult;
        }

        public Family GetFamily(string streetName, int houseNumber)
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

            return family;
        }
        

        public Family GetFamilyFromAdult(int id)
        {
            foreach (Family xFamily in _fileContext.Families)
            {
                Adult[] adults = xFamily.Adults.ToArray();
                foreach (Adult adult in adults)
                {
                    if (adult.Id == id)
                        return xFamily;
                }
            }

            return null;
        }
    }
}