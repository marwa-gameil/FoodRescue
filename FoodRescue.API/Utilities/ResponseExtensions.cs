using FoodRescue.Application.Responses;

namespace FoodRescue.Presentation.Utilities;

public static class ResponseE0tensions
{
    public static TResultType GetResult<TResultType>(this BaseResponse response) =>
        ((OkResponse<TResultType>)response).Result;
}
