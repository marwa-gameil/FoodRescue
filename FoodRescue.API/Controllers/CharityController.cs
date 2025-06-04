using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using FoodRescue.Application.Services;
using FoodRescue.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace FoodRescue.API.Controllers
{
    public class CharityController : ApiBaseController
    {
        private readonly ICharityService _charityService;

        public CharityController(ICharityService charityService)
        {
            _charityService = charityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharityDto>>>GetAll() =>
             HandleResult(await _charityService.GetAllCharitiesAsync());
        

        [HttpGet("{id}")]
        public async Task<ActionResult<CharityDto>>GetById(Guid id) =>
             HandleResult(await _charityService.GetCharityByIdAsync(id));

        [HttpPatch("{id}")]
        public async Task<ActionResult>ActivateCharity(Guid id) =>
            HandleResult(await _charityService.ActivateCharity(id));
        /*
        [HttpPost]
        public async Task<ActionResult<CharityDto>>AddCharity([FromForm] CharityCreatDto charityCreatDto) =>
            HandleResult(await _charityService.AddCharityAsync(charityCreatDto));


        [HttpDelete("{id}")]
        public async Task<ActionResult>DeleteCharity(Guid id) =>
            HandleResult(await _charityService.DeleteCharityAsync(id));


        */


    }
}
