using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("TableMV1_VEHICLE")]
    public partial class TableMv1Vehicle
    {
        [Key]
        [Column("ID_VEHICLE")]
        public int IdVehicle { get; set; }
        [Column("vin_no")]
        [Required (ErrorMessage ="حقل مطلوب")]
        //[StringLength(15,ErrorMessage ="رقم الشاصي اكثر من 15 رمز")]
        public string VinNo { get; set; }
        [Column("vehicle_body_type")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleBodyType { get; set; }
        [Column("vehicle_body_Name")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleBodyName { get; set; }
        [Column("vehicle_name")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleName { get; set; }
        [Column("id_vechicle")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string IdVechicle { get; set; }
        [Column("plate_number")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string PlateNumber { get; set; }
        [Column("payload")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string Payload { get; set; }
        [Column("passengers_no")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string PassengersNo { get; set; }
        [Column("wheel_no")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string WheelNo { get; set; }
        [Column("vehicle_model")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleModel { get; set; }
        [Column("vehicle_brand")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleBrand { get; set; }
        [Column("vehicle_price")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehiclePrice { get; set; }
        [Column("vehicle_administrator")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string VehicleAdministrator { get; set; }
        [Column("document_no")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string DocumentNo { get; set; }
        [Column("document_date")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string DocumentDate { get; set; }
        [Column("notes_me")]
        //[StringLength(1000)]
        [Required (ErrorMessage ="حقل مطلوب")  ]
         public string NotesMe { get; set; }
        [Column("status_last_vehicle_movement")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicleMovement { get; set; }
        [Column("status_last_vehicle")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicle { get; set; }
        [Column("status_last_vehicle_color")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicleColor { get; set; }
        [Column("status_last_armored")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastArmored { get; set; }
        [Column("status_last_hours_work")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastHoursWork { get; set; }
        [Column("status_last_kilometers")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastKilometers { get; set; }
        [Column("status_last_vehicle_consuming_rate")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicleConsumingRate { get; set; }
        [Column("status_last_vehicle_warehouse")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicleWarehouse { get; set; }
        [Column("status_last_vehicle_source")]
        //[StringLength(50)]
        [Required (ErrorMessage ="حقل مطلوب")]
        public string StatusLastVehicleSource { get; set; }
        [Column("date_add")]
        //[StringLength(50)]
         public string DateAdd { get; set; }
    }
}
