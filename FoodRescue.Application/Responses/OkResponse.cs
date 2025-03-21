namespace FoodRescue.Application.Responses;

public record OkResponse<TResult>(TResult Result) : BaseResponse(200);
