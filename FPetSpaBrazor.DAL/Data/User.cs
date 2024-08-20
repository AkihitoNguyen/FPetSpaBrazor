using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.DAL.Data;

public partial class User
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Gmail { get; set; } = null!;

    public bool? GmailConfirmed { get; set; }

    public string? UserAvatar { get; set; }

    public string? Phone { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public string? Password { get; set; }
}
