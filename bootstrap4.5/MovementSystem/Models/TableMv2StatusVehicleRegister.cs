using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("TableMV2_STATUS_VEHICLE_REGISTER")]
    public partial class TableMv2StatusVehicleRegister
    {
        [Key]
        [Column("ID_STATUS_VEHICLE_REGISTER")]
        public int IdStatusVehicleRegister { get; set; }
        [Column("ID_VEHICLE")]
        public int? IdVehicle { get; set; }
        [Column("vehicle_color")]
        [StringLength(50)]
        public string VehicleColor { get; set; }
        [Column("vehicle_armored")]
        [StringLength(50)]
        public string VehicleArmored { get; set; }
        [Column("vehicle_hours_work")]
        [StringLength(50)]
        public string VehicleHoursWork { get; set; }
        [Column("vehicle_kilometers")]
        [StringLength(50)]
        public string VehicleKilometers { get; set; }
        [Column("vehicle_consuming_rate")]
        [StringLength(50)]
        public string VehicleConsumingRate { get; set; }
        [Column("vehicle_warehouse")]
        [StringLength(50)]
        public string VehicleWarehouse { get; set; }
        [Column("vehicle_source")]
        [StringLength(50)]
        public string VehicleSource { get; set; }
        [Column("date_add")]
        [StringLength(50)]
        public string DateAdd { get; set; }
    }
}
