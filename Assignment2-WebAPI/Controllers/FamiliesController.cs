using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_WebAPI.Data;
using Assignment2_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private readonly IData _data;

        public FamiliesController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {

                IList<Family> tempFamilies = _data.GetFamilies();
                IList<Family> families = new List<Family>();
                foreach (Family family in tempFamilies.ToList()) {
                        families.Add(family);
                }

                families = tempFamilies;
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{streetNumber}/{houseNumber}")]
        public async Task<ActionResult<Family>> GetFamily([FromRoute] string streetNumber,[FromRoute] int? houseNumber)
        {
            Family family = null;
            try
            {
                if (streetNumber != null && houseNumber!=null)
                {
                    family = _data.GetFamily(streetNumber,houseNumber.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return family;
        }
        

        [HttpPost]
        public async Task<ActionResult<Adult>> PostFamily([FromBody] Family family)
        {
            try
            {
                IData data = new JsonData();
                {
                    data.AddFamily(family);
                }
                return Ok(family);
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Family>> PatchFamily([FromBody] Family family)
        {
            Family familyToUpdate = _data.GetFamily(family.StreetName, family.HouseNumber);
            familyToUpdate.Adults = family.Adults;
            familyToUpdate.Children = family.Children;
            familyToUpdate.Pets = family.Pets;
            try
            {
                IData data = new JsonData();
                data.UpdateFamily(familyToUpdate);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            return Ok(family);
        }
    }
}