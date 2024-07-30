using OnlineStore.Models.RacketsModels;

namespace OnlineStore.Contracts
{
    public record Racket(
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
        List<Image> Images,
        string Desc,
        string ImageUrl
    );
    public record RacketRequest(
        Guid Id
    );
}
