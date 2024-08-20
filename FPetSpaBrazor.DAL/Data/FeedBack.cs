using System;
using System.Collections.Generic;

namespace FPetSpaBrazor.DAL.Data;

public partial class FeedBack
{
    public int Id { get; set; }

    public string? UserFeedBackId { get; set; }

    public string? ProductId { get; set; }

    public string? PictureName { get; set; }

    public int? Star { get; set; }

    public string? Description { get; set; }
}
