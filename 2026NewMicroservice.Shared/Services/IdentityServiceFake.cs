namespace _2026NewMicroservice.Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("2413eca0-8862-4753-90f6-6ea07818dfcd");

        public string GetUserName => "Ali_06";
    }
}
