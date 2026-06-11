using _2026NewMicroservice.Order.Api.Endpoints.Order;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Order.Api.Endpoints
{
    public static class OrderEnpointExtension
    {
        public static void AddOrderEnpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {

            app.MapGroup("api/v{version:apiVersion}/orders")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Orders")
                .MapCreateOrderEnpoint();
        }
    }
}
