﻿using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.DAL.Data;

public partial class Notification
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }
}
