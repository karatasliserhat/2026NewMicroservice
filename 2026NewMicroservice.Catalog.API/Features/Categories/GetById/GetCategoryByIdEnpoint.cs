namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetById
{
    public static class GetCategoryByIdEnpoint
    {
        public static RouteGroupBuilder MapGetCategoryByIdEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator)
                => (await mediator.Send(new GetCategoryByIdQuery(id)))
                .ToGenericResult())
                .WithName("GetCategoryById")
                .Produces<CategoryDto>(StatusCodes.Status200OK)
                .Produces<CategoryDto>(StatusCodes.Status404NotFound);
            return group;
        }
    }
}
