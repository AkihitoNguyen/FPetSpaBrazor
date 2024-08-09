using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class Pet
{
    public string PetId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string? PetName { get; set; }

    public string? PictureName { get; set; }

    public int? TypeId { get; set; }

    public decimal? PetWeight { get; set; }
}
