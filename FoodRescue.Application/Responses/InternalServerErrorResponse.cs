namespace FoodRescue.Application.Responses;

public record InternalServerErrorResponse(string Message = "Something went wrong") : BaseResponse(500);
