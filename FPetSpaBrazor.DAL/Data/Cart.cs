using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.DAL.Data;

public partial class Cart
{
    public string CartId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }
}
