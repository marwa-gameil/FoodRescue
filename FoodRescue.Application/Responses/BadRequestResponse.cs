namespace FoodRescue.Application.Responses;

public record BadRequestResponse(string Message) : BaseResponse(400);
