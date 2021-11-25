using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_WebAPI.Data;
using Assignment3_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private readonly IData _data;

        public AdultsController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{adultId}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int? adultId)
        {
            try
            {
                if (adultId != null)
                {
                    Adult adult = _data.GetAdult(adultId.Value);

                    return Ok(adult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return null;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int? adultId,[FromQuery] string sex )
        {
            try
            {

                IList<Adult> tempAdults = _data.GetAdults();
                IList<Adult> adults = new List<Adult>();
                if (adultId != null)
                {
                    adults.Add(tempAdults.First(adult => adult.Id == adultId));
                }
                else if (sex != null)
                {
                    foreach (Adult adult in tempAdults.ToList())
                    {
                        if (adult.Sex == sex)
                        {
                            adults.Add(adult);
                            tempAdults.Remove(adult);
                        }

                    }

                    foreach (Adult adult in tempAdults.ToList())
                    {
                        adults.Add(adult);
                    }
                }
                else
                {
                    adults = tempAdults;
                }

                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdult([FromBody] Adult adult)
        {
            try
            {
                IData data = new JsonData();
                data.AddAdult(adult);
                
                return Ok(adult);
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdult([FromQuery] int adultId)
        {
            try
            {
                _data.RemoveAdult(adultId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return Ok();
        }
        
        [HttpPatch]
        public async Task<ActionResult<Adult>> PatchAdult([FromBody] Adult adult)
        {
            Adult adultToUpdate = _data.GetAdult(adult.Id);
            adultToUpdate.JobTitle = adult.JobTitle;
            adultToUpdate.Weight = adult.Weight;
            adultToUpdate.Height = adult.Height;
            adultToUpdate.HairColor = adult.HairColor;
            try
            {
                IData data = new JsonData();
                data.UpdateAdult(adultToUpdate);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            return Ok(adult);
        }

    }
    
}