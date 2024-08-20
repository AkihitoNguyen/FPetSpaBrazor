using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.DAL.Data;

public partial class BookingTime
{
    public int Id { get; set; }

    public TimeOnly BookingTime1 { get; set; }

    public DateOnly? Date { get; set; }

    public int? MaxSlots { get; set; }
}
