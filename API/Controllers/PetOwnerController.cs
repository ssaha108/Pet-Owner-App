using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.DTOs;
using API.Entities;

using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class PetOwnerController : BaseApiController
    {
        private readonly IPetOwnerServices _petOwnerServices;    

        public PetOwnerController(IPetOwnerServices petOwnerServices)
        {
            _petOwnerServices = petOwnerServices;
        }

        [HttpGet("catsbygender")]
        public async Task<ActionResult<IEnumerable<GenderCatsDTO>>> GetCatsByOwnerGender()
        {
           try
            {
                var genderCats = await _petOwnerServices.GetCatsByOwnerGender();
                return Ok(genderCats);
            }
            catch { return StatusCode(500,"API server says no!"); }
        }

    }
}