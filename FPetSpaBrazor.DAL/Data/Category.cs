﻿using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
