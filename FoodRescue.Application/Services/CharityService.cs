using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using FoodRescue.Application.Utilities;
using FoodRescue.Domain.Interfaces;
using FoodRescue.Domain.Models;
using FoodRescue.Domain.Responses;
using FoodRescue.Domain.Specifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Services
{
    public class CharityService : ICharityService
    {
        private readonly IRepository<Charity> _charities;
        private readonly UserManager<User> _userManager;

        string _domain;
        public CharityService(IRepository<Charity> charities, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _charities = charities;
            _userManager = userManager;
            _domain = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host.Value}";

        }

        public async Task<Result> ActivateCharity(Guid id)
        {
            var charity = await _charities.GetById(id);
            if (charity == null)
            {
                return Result.Fail(AppResponses.NotFoundResponse(id, nameof(charity)));
            }
            charity.IsVerfied = true;
            _charities.Update(charity);
            await _charities.Save();
            return Result.Success(statusCode:StatusCodes.Status204NoContent);
        }

        public async Task<Result<CharityDto>> AddCharityAsync(CharityCreatDto charityDto)
        {
            var user = await _userManager.FindByIdAsync(charityDto.UserId.ToString());   
            if (user == null)
            {
                return Result.Fail<CharityDto>(AppResponses.NotFoundResponse(charityDto.UserId, nameof(User)));
            }
            string fileName = $"Charity_{user.Name}_{Guid.NewGuid()}.pdf";
          
            var folderPath = Path.Combine("wwwroot", "docs");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await charityDto.VerificationDocument.CopyToAsync(stream);
            }
            Charity charity = new Charity
            {
                UserId = charityDto.UserId,
                IsVerfied = false,
                VerificationDocument = fileName
            };
            await _charities.Add(charity);
            await _charities.Save();
            var charitydto= new CharityDto
            {
                Id = charity.Id,
                UserName = user.Name,
                IsVerfied = false,
                UserId = user.Id,
                VerificationDocumentURL = $"{_domain}/docs/{charity.VerificationDocument}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address= user.Address
                
            };

            return Result.Success(charitydto);

        }

    
        public async Task<Result> DeleteCharityAsync(Guid id)
        {
            var charity = await _charities.GetById(id);
            if(charity is null)
                return Result.Fail(AppResponses.NotFoundResponse(id, nameof(User)));
            var user = await _userManager.FindByIdAsync(charity.UserId.ToString());
            _charities.Delete(charity);
            await _userManager.DeleteAsync(user);
            await _charities.Save();
            return Result.Success(statusCode:StatusCodes.Status204NoContent);
        }

        public async Task<Result<IEnumerable<CharityDto>>> GetAllCharitiesAsync()
        {
            var charityWithUser = new Specification<Charity, CharityDto>();
            charityWithUser.Selector = charity => new CharityDto
            {
                Id = charity.Id,
                UserName = charity.User.Name,
                IsVerfied = charity.IsVerfied,
                UserId = charity.UserId,
                VerificationDocumentURL = $"{_domain}/docs/{charity.VerificationDocument}",
                Email = charity.User.Email,
                PhoneNumber = charity.User.PhoneNumber,
                Address = charity.User.Address

            };
            return Result.Success(await _charities.GetAll(charityWithUser));
            
            
        }

        public async Task<Result<CharityDto>> GetCharityByIdAsync(Guid id)
        {
           
            var charityWithUser = new Specification<Charity,CharityDto>(charity=>charity.Id == id);
            charityWithUser.Selector = charity => new CharityDto
            {
                Id = charity.Id,
                UserName = charity.User.Name,
                IsVerfied = charity.IsVerfied,
                UserId = charity.UserId,
                VerificationDocumentURL = $"{_domain}/docs/{charity.VerificationDocument}",
                Email = charity.User.Email,
                PhoneNumber = charity.User.PhoneNumber,
                Address = charity.User.Address
            };
            var charity = await _charities.GetOne(charityWithUser);
            if(charity == null) 
                return Result.Fail<CharityDto>(AppResponses.NotFoundResponse(id, nameof(charity)));
            return Result.Success(charity);
        }

    }
}
