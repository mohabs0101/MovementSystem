using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("RootMV1_VEHICLE_BODY_NAMES")]
    public partial class RootMv1VehicleBodyName
    {
        [Key]
        [Column("ID_VEHICLE_BODY_NAME")]
        public int IdVehicleBodyName { get; set; }
        [Column("vehicle_body_name2")]
        [StringLength(50)]
        public string VehicleBodyName2 { get; set; }
    }
}
