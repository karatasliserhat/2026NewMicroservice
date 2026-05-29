namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetAll
{
    public static class GetAllCategoryGroupItemEndpoint
    {
        public static RouteGroupBuilder MapGetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediatR)
                => (await mediatR.Send(new GetAllCategoryQuery()))
                .ToGenericResult())
                .WithName("GetAllCategories")
                .Produces<List<CategoryDto>>(StatusCodes.Status200OK);

            return group;
        }
    }
}
