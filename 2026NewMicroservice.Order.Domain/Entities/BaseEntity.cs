namespace _2026NewMicroservice.Order.Domain.Entities
{
    public class BaseEntity<TEntityId>
    {
        public TEntityId Id { get; set; } = default!;
    }
}
