using Microsoft.AspNetCore.Mvc;
using FoodRescue.Application.Responses;
using FoodRescue.Application.Interfaces;
using FoodRescue.Presentation.Utilities;

namespace FoodRescue.Presentation.Controllers;

[Route("Api/[controller]")]
public abstract class GenericController<TCreateDTO, TUpdateDTO, TResponseDTO> : ControllerBase
{
    protected readonly IService<TCreateDTO, TUpdateDTO> _service;

    public GenericController(IService<TCreateDTO, TUpdateDTO> service) =>
        _service = service;

    [HttpGet]
    public async virtual Task<IActionResult> Get() =>
        Ok(
            (await _service.GetAll())
            .GetResult<IEnumerable<TResponseDTO>>()
        );

    [HttpGet("{id}")]
    public async virtual Task<IActionResult> Get(Guid id)
    {
        BaseResponse response = await _service.GetById(id);
        return response.StatusCode == 200 ? Ok(response.GetResult<TResponseDTO>()) : ProcessError(response);
    }

    [HttpPost]
    public async virtual Task<IActionResult> Create(TCreateDTO createDTO)
    {
        BaseResponse response = await _service.Create(createDTO);
        if(response.StatusCode != 201) return ProcessError(response);
        var result = response.GetResult<TResponseDTO>();
        int inde0 = this.GetType().ToString().Split('.').Last().IndexOf("Controller");
        string path = this.GetType().ToString().Split('.').Last().Remove(inde0);
        return Created($"/api/{path}/{result!.GetType().GetProperty("Id")!.GetValue(result)}", result);
    }

    [HttpPut]
    public async virtual Task<IActionResult> Update(Guid Id, TUpdateDTO updateDTO)
    {
        BaseResponse response = await _service.Update(Id, updateDTO);
        int inde0 = this.GetType().ToString().Split('.').Last().IndexOf("Controller");
        string path = this.GetType().ToString().Split('.').Last().Remove(inde0);
        return response.StatusCode switch
        {
            201 => Created($"/api/{path}/{Id}", response.GetResult<TResponseDTO>()),
            _ => ProcessError(response)
        };
    }

    [HttpDelete("{id}")]
    public async virtual Task<IActionResult> Delete(Guid id)
    {
        BaseResponse response = await _service.Delete(id);
        return response.StatusCode == 204 ? NoContent() : ProcessError(response);
    }

    protected IActionResult ProcessError(BaseResponse response)
    {
        return response.StatusCode switch
        {
            400 => BadRequest((BadRequestResponse)response),
            401 => Unauthorized((UnAuthorizedResponse)response),
            403 => Forbid(((ForbiddenResponse)response).Message),
            404 => NotFound((NotFoundResponse)response),
            500 => StatusCode(response.StatusCode, ((InternalServerErrorResponse)response).Message),
            _ => throw new NotImplementedException()
        };
    }
}
