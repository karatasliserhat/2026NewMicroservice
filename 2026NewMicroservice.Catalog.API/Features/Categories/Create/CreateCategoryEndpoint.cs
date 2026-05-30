
using Microsoft.AspNetCore.Mvc;

namespace _2026NewMicroservice.Catalog.API.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder MapCreateCategoryEndpoint(this RouteGroupBuilder group)
        {

            group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator)
                => (await mediator.Send(command))
                    .ToGenericResult())
                .WithName("CreateCategory")
                .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return group;
        }
    }
}
