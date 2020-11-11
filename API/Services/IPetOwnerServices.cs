using API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IPetOwnerServices
    {
        Task<List<GenderCatsDTO>> GetCatsByOwnerGender();
    }
}