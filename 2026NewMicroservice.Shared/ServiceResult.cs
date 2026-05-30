using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
using System.Net;
using System.Text.Json.Serialization;
using Refit;
using System.Text.Json;
using MediatR;

namespace _2026NewMicroservice.Shared
{


    public interface IRequestServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestServiceResult : IRequest<ServiceResult>;
    public class ServiceResult
    {
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        public ProblemDetails? Fail { get; set; }


        [JsonIgnore] public bool IsSuccess => Fail is null;
        [JsonIgnore] public bool IsFailure => !IsSuccess;


        public static ServiceResult SuccessAsNoContent() => new ServiceResult { Status = HttpStatusCode.NoContent };
        public static ServiceResult ErrorAsNotFound() => new ServiceResult { Status = HttpStatusCode.NotFound, Fail = new ProblemDetails { Title = "Not Found", Detail = "The requested resource was not found." } };



        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode statusCode) => new ServiceResult { Status = statusCode, Fail = problemDetails };
        public static ServiceResult Error(string title, string description, HttpStatusCode status) => new ServiceResult { Status = status, Fail = new ProblemDetails { Title = title, Detail = description } };
        public static ServiceResult Error(string title, HttpStatusCode status) => new ServiceResult { Status = status, Fail = new ProblemDetails { Title = title } };

        public static ServiceResult ErrorFromProblemDetail(ApiException apiException)
        {

            if (string.IsNullOrEmpty(apiException.Content))
            {
                return new ServiceResult
                {
                    Status = apiException.StatusCode,
                    Fail = new ProblemDetails
                    {
                        Title = $"API Error: {apiException.StatusCode}",
                        Detail = "An error occurred while calling the API, but no additional details were provided."
                    }
                };
            }

            var problemDetail = JsonSerializer.Deserialize<ProblemDetails>(apiException.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return new ServiceResult
            {
                Status = apiException.StatusCode,
                Fail = problemDetail ?? new ProblemDetails
                {
                    Title = $"API Error: {apiException.StatusCode}",
                    Detail = "An error occurred while calling the API, but the error details could not be parsed."
                }
            };
        }

        public static ServiceResult ErrorFromValidation(Dictionary<string, object?> errors) => new ServiceResult
        {
            Status = HttpStatusCode.BadRequest,
            Fail = new ProblemDetails
            {
                Title = "Validation Error",
                Detail = "One or more validation errors occurred.",
                Extensions = { ["errors"] = errors }
            }
        };
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        [JsonIgnore] public string? UrlCreated { get; set; }

        public static ServiceResult<T> SuccessAsOk(T data) => new ServiceResult<T> { Status = HttpStatusCode.OK, Data = data };

        public static ServiceResult<T> SuccessAsCreated(T data, string urlCreated) => new ServiceResult<T> { Status = HttpStatusCode.Created, Data = data, UrlCreated = urlCreated };

        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode statusCode) => new ServiceResult<T> { Status = statusCode, Fail = problemDetails };
        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode) => new ServiceResult<T> { Status = statusCode, Fail = new ProblemDetails { Title = title, Detail = description, Status = (int)statusCode } };
        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode) => new ServiceResult<T> { Status = statusCode, Fail = new ProblemDetails { Title = title } };

        public new static ServiceResult<T> ErrorFromProblemDetail(ApiException apiException)
        {

            if (string.IsNullOrEmpty(apiException.Content))
            {
                return new ServiceResult<T>
                {
                    Status = apiException.StatusCode,
                    Fail = new ProblemDetails
                    {
                        Title = $"API Error: {apiException.StatusCode}",
                        Detail = "An error occurred while calling the API, but no additional details were provided."
                    }
                };
            }

            var problemDetail = JsonSerializer.Deserialize<ProblemDetails>(apiException.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return new ServiceResult<T>
            {
                Status = apiException.StatusCode,
                Fail = problemDetail ?? new ProblemDetails
                {
                    Title = $"API Error: {apiException.StatusCode}",
                    Detail = "An error occurred while calling the API, but the error details could not be parsed."
                }
            };
        }

        public new static ServiceResult<T> ErrorFromValidation(Dictionary<string, object?> errors) => new ServiceResult<T>
        {
            Status = HttpStatusCode.BadRequest,
            Fail = new ProblemDetails
            {
                Title = "Validation Error",
                Detail = "One or more validation errors occurred.",
                Extensions = { ["errors"] = errors }
            }
        };
    }

}
