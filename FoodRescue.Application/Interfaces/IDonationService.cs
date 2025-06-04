using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Models;
using FoodRescue.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Interfaces

{
    public interface IDonationService
    {
        Task<Result<Donationdto>> GetDonationByIdAsync(Guid id);
        Task<Result<IEnumerable<Donationdto>>> GetAllDonationAsync();
        Task<Result<Donationdto>> AddDonationAsync(DonationCreateDto donation);
        Task<Result<Donationdto>> UpdateDonationAsync(Guid id, DonationCreateDto donation);
        Task<Result> DeleteDonationAsync(Guid id);
    }
}