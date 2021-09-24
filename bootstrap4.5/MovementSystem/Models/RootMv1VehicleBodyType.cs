using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("RootMV1_VEHICLE_BODY_TYPE")]
    public partial class RootMv1VehicleBodyType
    {
        [Key]
        [Column("ID_VEHICLE_BODY_TYPE")]
        public int IdVehicleBodyType { get; set; }
        [Column("vehicle_body_name")]
        [StringLength(50)]
        public string VehicleBodyName { get; set; }
        [Column("vehicle_image", TypeName = "image")]
        public byte[] VehicleImage { get; set; }
    }
}
