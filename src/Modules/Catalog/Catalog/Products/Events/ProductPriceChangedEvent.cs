namespace Catalog.Products.Events
{
    public record ProductPriceChangedEvent(Product Product) : IDomainEvent;
    public record ProductProductCreatedEvent(Product Product) : IDomainEvent;

}
