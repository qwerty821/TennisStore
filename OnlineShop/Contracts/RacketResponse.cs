namespace OnlineStore.Contracts
{
    public record RacketResponse(
        Guid Id,
        string Name, 
        string Brand,
        decimal Price,
        string ImageUrl
    );

    public record RacketDetailResponse(
        Guid Id,
        string Name,
        string Brand,
        decimal Price,
        List<string> ImageUrl,
        string Desc
    );
    public record RacketRequest(
        Guid Id
    );
}
