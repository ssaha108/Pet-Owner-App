using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using API.Entities;
using API.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace API.Services
{
    public class PetOwnerServices : IPetOwnerServices
    {
        private static HttpClient _httpClient = new HttpClient();
        private readonly IWebHostEnvironment _env;
        private readonly string _jsonTestDataSource;
        
        public PetOwnerServices(IConfiguration config, IWebHostEnvironment env)
        {
            _env = env;
            _jsonTestDataSource = config["JsonTestDataSource"] ;
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<List<GenderCatsDTO>> GetCatsByOwnerGender()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _jsonTestDataSource);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var petOwners = JsonConvert.DeserializeObject<List<PetOwner>>(content).ToList();

            List<GenderCatsDTO> genderCats = new List<GenderCatsDTO>(); 
               
            petOwners.ForEach(p =>
            {
                if (!genderCats.Any(x => x.Gender == p.Gender))
                    genderCats.Add(new GenderCatsDTO { Gender = p.Gender, Cats = new List<CatDTO>() });

                if (p.Pets!=null && p.Pets.Any(c => c.Type == (int)TypeEnum.Cat))
                {
                    List<CatDTO> cName = p.Pets.Where(c => c.Type == (int)TypeEnum.Cat).Select(n => new CatDTO { CatName = n.Name }).ToList();
                    (genderCats.Where(gC => gC.Gender == p.Gender).Select(c => c.Cats)).FirstOrDefault().AddRange(cName);
                }
            });

            genderCats.ForEach(g => 
                g.Cats = (from c in g.Cats orderby c.CatName select c).ToList()
            );

            return genderCats;
        }
    }
}