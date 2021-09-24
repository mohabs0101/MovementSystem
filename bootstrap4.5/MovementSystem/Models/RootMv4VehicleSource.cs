using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("RootMV4_VEHICLE_SOURCE")]
    public partial class RootMv4VehicleSource
    {
        [Key]
        [Column("ID_VEHICLE_SOURCE")]
        public int IdVehicleSource { get; set; }
        [Column("vehicle_source")]
        [StringLength(50)]
        public string VehicleSource { get; set; }
    }
}
