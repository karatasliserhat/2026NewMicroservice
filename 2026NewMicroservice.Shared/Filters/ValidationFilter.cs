using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _2026NewMicroservice.Shared.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {

            var validation = context.HttpContext.RequestServices.GetService<IValidator<T>>();

            if (validation is null)
                await next.Invoke(context);


            var requestModel = context.Arguments.OfType<T>().FirstOrDefault();

            if (requestModel is null)
                await next.Invoke(context);

            var validationResult = await validation!.ValidateAsync(requestModel!);

            if (!validationResult.IsValid)
            {

                return Results.ValidationProblem(validationResult.ToDictionary());
            }


            return await next.Invoke(context);
        }
    }
}
