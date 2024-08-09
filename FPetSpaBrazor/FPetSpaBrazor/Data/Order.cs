using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.Data;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string? StaffId { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? BookingTime { get; set; }

    public decimal? Total { get; set; }

    public string? VoucherId { get; set; }

    public string? TransactionId { get; set; }

    public byte? Status { get; set; }

    public string? DeliveryOption { get; set; }

    public virtual ICollection<ProductOrderDetail> ProductOrderDetails { get; set; } = new List<ProductOrderDetail>();

    public virtual Transaction? Transaction { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
