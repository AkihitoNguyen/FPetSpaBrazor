using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class StaffStatus
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public int Status { get; set; }

    public string? StaffName { get; set; }
}
