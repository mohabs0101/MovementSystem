using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("RootMV2_VEHICLE_NAME")]
    public partial class RootMv2VehicleName
    {
        [Key]
        [Column("ID_VEHICLE_NAME")]
        public int IdVehicleName { get; set; }
        [Column("vehicle_name")]
        [StringLength(50)]
        public string VehicleName { get; set; }
    }
}
