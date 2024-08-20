using Microsoft.AspNetCore.Identity;

namespace FPetSpaBrazor.DAL.Data;

    public class ApplicationUser : IdentityUser
    {
    public string FullName { get; set; } = null!;

    public string? UserAvatar { get; set; }

    public string? Phone { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }
    }



