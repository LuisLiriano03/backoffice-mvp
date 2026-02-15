using System;
using System.Collections.Generic;

namespace BackOffice.Domain.Entities;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public int? HotelId { get; set; }

    public string? RoomTypeName { get; set; }

    public int? Capacity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
