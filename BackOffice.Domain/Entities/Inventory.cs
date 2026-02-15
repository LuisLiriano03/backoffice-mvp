using System;
using System.Collections.Generic;

namespace BackOffice.Domain.Entities;

public partial class Inventory
{
    public int InventoriesId { get; set; }

    public int? RoomTypeId { get; set; }

    public DateTime? InventoryDate { get; set; }

    public int? TotalRooms { get; set; }

    public int? AvailableRooms { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual RoomType? RoomType { get; set; }
}
