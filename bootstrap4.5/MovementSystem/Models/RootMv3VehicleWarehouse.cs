using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("RootMV3_VEHICLE_WAREHOUSE")]
    public partial class RootMv3VehicleWarehouse
    {
        [Key]
        [Column("ID_VEHICLE_WAREHOUSE")]
        public int IdVehicleWarehouse { get; set; }
        [Column("warehouse_name")]
        [StringLength(50)]
        public string WarehouseName { get; set; }
    }
}
