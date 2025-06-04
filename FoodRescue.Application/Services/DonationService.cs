using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Interfaces;
using FoodRescue.Domain.Models;
using FoodRescue.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodRescue.Application.Interfaces;
using FoodRescue.Domain.Responses;
using Microsoft.AspNetCore.Http;

namespace FoodRescue.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly IRepository<Donation> _donations;
        private readonly IRepository<Charity> _charities;
        private readonly ICurrentLoggedInUser _user;


        public DonationService(
            IRepository<Donation> donations,
            IRepository<Charity> charities ,
            ICurrentLoggedInUser user
            )
        {
            _donations = donations;
            _charities = charities;
            _user = user;

        }

        public async Task<Result<Donationdto>> AddDonationAsync(DonationCreateDto donation)
        {
            var charity = await _charities.GetById(donation.CharityId);
            if (charity is null)
            {
                return Result.Fail<Donationdto>(AppResponses.NotFoundResponse(donation.CharityId, nameof(Charity)));
            }
       
            Donation newDonation = new Donation(Guid.NewGuid())
            {
                FoodType = donation.FoodType,
                Quantity = donation.Quantity,
                PickupTime = donation.PickupTime,
                Status = Donation.DonationStatus.Pending,
                Location = donation.Location,
                CharityId = donation.CharityId,
                UserId =new Guid(_user.UserId)
            };

            await _donations.Add(newDonation);
            await _donations.Save();

            var query = new Specification<Donation, Donationdto>(d => d.Id == newDonation.Id);
            query.IncludeStrings.Add("Charity.User");
            query.Selector = d => new Donationdto
            {
                Id = d.Id,
                FoodType = d.FoodType,
                Quantity = d.Quantity,
                PickupTime = d.PickupTime,
                Status = d.Status.ToString(),
                Location = d.Location,
                DonorId = d.UserId,
                DonerName = d.Doner != null ? d.Doner.Name : string.Empty,
                CharityId = d.CharityId,
                CharityName = d.Charity != null && d.Charity.User != null ? d.Charity.User.Name : string.Empty
            };

            var dto = await _donations.GetOne(query);
            return Result.Success(dto, StatusCodes.Status201Created);
        }




        public async Task<Result> DeleteDonationAsync(Guid id)
        {
            var donation = await _donations.GetOne(new Specification<Donation>(donation => donation.Id==id));
            if (donation == null)
            {
                Result.Fail(AppResponses.NotFoundResponse(id, nameof(Donation)));

            }
            _donations.Delete(donation);
            await _donations.Save();
            return Result.Success(statusCode: StatusCodes.Status204NoContent);

        }

        public async Task<Result<IEnumerable<Donationdto>>> GetAllDonationAsync()
        {
            var query = new Specification<Donation, Donationdto>();
            query.IncludeStrings.Add("Charity.User");
            query.Selector = donation => new Donationdto
            {
                Id = donation.Id,
                FoodType = donation.FoodType,
                Quantity = donation.Quantity,
                PickupTime = donation.PickupTime,
                Status = donation.Status.ToString(),
                Location = donation.Location,

                DonorId = donation.UserId,
                DonerName = donation.Doner.Name,

                CharityId = donation.CharityId,
                CharityName = donation.Charity.User.Name
            };
            return Result.Success(await _donations.GetAll(query));
        }

        public async Task<Result<Donationdto>> GetDonationByIdAsync(Guid id)
        {
            var query = new Specification<Donation, Donationdto>(donation => donation.Id == id);
            query.IncludeStrings.Add("Charity.User");
            query.Selector = donation => new Donationdto
            {
                Id = donation.Id,
                FoodType = donation.FoodType,
                Quantity = donation.Quantity,
                PickupTime = donation.PickupTime,
                Status = donation.Status.ToString(),
                Location = donation.Location,

                DonorId = donation.UserId,
                DonerName = donation.Doner.Name,

                CharityId = donation.CharityId,
                CharityName = donation.Charity.User.Name
            };
            return Result.Success(await _donations.GetOne(query));

        }
        
        //to do update
        public async Task<Result<Donationdto>> UpdateDonationAsync(Guid id, DonationCreateDto donation)
        {
            throw new NotImplementedException();
        }
        
    }
        
}