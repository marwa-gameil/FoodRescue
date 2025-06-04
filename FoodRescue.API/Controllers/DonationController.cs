using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using FoodRescue.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodRescue.API.Controllers
{
    public class DonationController : ApiBaseController

    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donationdto>>> GetAll() =>
                HandleResult(await _donationService.GetAllDonationAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<Donationdto>> GetById(Guid id) =>
             HandleResult(await _donationService.GetDonationByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<Donationdto>> AddDonation([FromForm] DonationCreateDto donation) =>
            HandleResult(await _donationService.AddDonationAsync(donation));

        [HttpPut("{id}")]
        public async Task<ActionResult<Donationdto>> UpdateDonation(Guid id, [FromForm] DonationCreateDto donation) =>
            HandleResult(await _donationService.UpdateDonationAsync(id, donation));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonation(Guid id) =>
            HandleResult(await _donationService.DeleteDonationAsync(id));



    }
}


