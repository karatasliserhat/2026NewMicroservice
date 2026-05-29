using Microsoft.AspNetCore.Http;
using System.Net;

namespace _2026NewMicroservice.Shared.Extensions
{
    public static class EnpointResultExtension
    {
        public static IResult ToGenericResult<T>(this ServiceResult<T> result)
        {

            return result.Status switch
            {
                HttpStatusCode.OK => Results.Ok(result.Data),
                HttpStatusCode.Created => Results.Created(result.UrlCreated,result.Data),
                HttpStatusCode.NotFound => Results.NotFound(result.IsFailure!),
                _ => Results.Problem(result.Fail!)

            };
        }
        public static IResult ToGenericResult(this ServiceResult result)
        {

            return result.Status switch
            {

                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
                _ => Results.Problem(result.Fail!)

            };
        }
    }
}
