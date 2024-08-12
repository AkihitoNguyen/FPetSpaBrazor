using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class ServiceOrderDetail
{
    public int Id { get; set; }

    public string? ServiceId { get; set; }

    public string? OrderId { get; set; }

    public double? Discount { get; set; }

    public decimal? PetWeight { get; set; }

    public decimal? Price { get; set; }

    public string PetId { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
