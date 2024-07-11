namespace OnlineStore.Models
{
    public record RacketEntity(
        Guid id, 
        string name, 
        string image_url, 
        decimal price, 
        string brand
    );
}
