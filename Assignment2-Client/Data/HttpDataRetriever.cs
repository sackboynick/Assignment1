using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment2_Client.Models;

namespace Assignment2_Client.Data
{
    public class HttpDataRetriever: IData
    {

        public async Task<List<Adult>> GetAdults()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using HttpClient client = new HttpClient(clientHandler);
            
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/Adults").ConfigureAwait(false);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adults;
        }

        public async Task<List<Family>> GetFamilies()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/Families").ConfigureAwait(false);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return families;
        }

        public async Task AddAdult(Adult adult)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            string adultsAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(
                adultsAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Adults", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async void AddAdultToFamily(int id, Family family)
        {
            Adult adult = GetAdult(id).Result;
            family.Adults.Add(adult);
            await UpdateFamily(family);
        }

        public async Task AddFamily(Family family)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            string familyAsJson = JsonSerializer.Serialize(family);
            StringContent content = new StringContent(
                familyAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Families", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task AddChild(Child child, Family family)
        {
            family.Children.Add(child);
            await UpdateFamily(family);
        }

        public async Task AddPet(Pet pet, Family family)
        {
            family.Pets.Add(pet);
            await UpdateFamily(family);
        }

        public async Task AddPetToChild(Pet pet, int childId, Family family)
        {
            foreach (Child child in family.Children)
            {
                if(child.Id==childId)
                    child.Pets.Add(pet);
            }

            await UpdateFamily(family);
        }

        public async Task AddInterestToChild(Interest interest, int childId, Family family)
        {
            foreach (Child child in family.Children)
            {
                if(child.Id==childId)
                    child.Interests.Add(interest);
            }

            await UpdateFamily(family);
        }

        public async Task UpdateAdult(Adult adult)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PatchAsync("https://localhost:5001/Adults", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task UpdateFamily(Family family)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            string familyAsJson = JsonSerializer.Serialize(family);
            StringContent content = new StringContent(
                familyAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PatchAsync("https://localhost:5001/Families", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task RemoveAdult(int adultId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/Adults?adultId="+adultId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task<Adult> GetAdult(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Adults/"+id).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Adult adult = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adult;
        }

        public async Task<Family> GetFamily(string streetName, int houseNumber)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Families/"+streetName+"/"+houseNumber).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Family family = JsonSerializer.Deserialize<Family>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return family;
        }

        private String CorrectStreetName(string streetName)
        {
            return streetName.Replace(" ", "%");
        }

        public Task<Family> GetFamilyFromAdult(int id)
        {
            List<Family> families = GetFamilies().Result;
            foreach (Family xFamily in families)
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
    }
}