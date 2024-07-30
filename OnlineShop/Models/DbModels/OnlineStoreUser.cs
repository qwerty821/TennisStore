using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models.DbModels;

// Add profile data for application users by adding properties to the OnlineStoreUser class
public class OnlineStoreUser : IdentityUser
{
    //public string? IP {  get; set; }
    public OnlineStoreUser()
    {
         
    }
}