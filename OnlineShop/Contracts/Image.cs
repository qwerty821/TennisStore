namespace OnlineStore.Contracts
{
    public record ImageEdit(Guid id, string ImageUrl);

    public record ImageAdd(Guid racket_id, string ImageUrl);
}
