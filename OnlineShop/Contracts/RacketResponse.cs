namespace OnlineStore.Contracts
{
    public record RacketResponse(
        Guid Id,
        string Name, 
        string Brand,
        decimal Price,
        string ImageUrl
    );

    public record RacketRequest(
        Guid Id
    );
}
