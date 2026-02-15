using System;
using System.Collections.Generic;

namespace BackOffice.Domain.Entities;

public partial class Reservation
{
    public Guid Id { get; set; }

    public int? HotelId { get; set; }

    public int? RoomTypeId { get; set; }

    public DateOnly CheckIn { get; set; }

    public DateOnly CheckOut { get; set; }

    public string ReservationStatus { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual RoomType? RoomType { get; set; }
}
