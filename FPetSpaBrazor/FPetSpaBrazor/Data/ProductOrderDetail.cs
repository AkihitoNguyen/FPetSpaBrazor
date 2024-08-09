using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class ProductOrderDetail
{
    public int Id { get; set; }

    public string? OrderId { get; set; }

    public string? ProductId { get; set; }

    public string? ProductPicture { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public double? Discount { get; set; }

    public virtual Order? Order { get; set; }
}
