using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Interfaces
{
    public interface ICharityService
    {
        Task<Result<CharityDto>> GetCharityByIdAsync(Guid id);
        Task<Result<IEnumerable<CharityDto>>> GetAllCharitiesAsync();
        Task <Result<CharityDto>> AddCharityAsync(CharityCreatDto charityCreateDto);
        Task <Result> ActivateCharity(Guid id);
        Task<Result> DeleteCharityAsync(Guid id);
    }
}
