using FoodRescue.Application.Responses;

namespace FoodRescue.Application.Interfaces;

public interface IService<TCreateDTO, TUpdateDTO>
{
    Task<BaseResponse> GetAll();
    Task<BaseResponse> GetById(Guid id);
    Task<BaseResponse> Create(TCreateDTO createDTO);
    Task<BaseResponse> Update(Guid id, TUpdateDTO updateDTO);
    Task<BaseResponse> Delete(Guid id);
}
