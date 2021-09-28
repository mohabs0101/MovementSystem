using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovementSystem.Controllers
{
    public class HomeController : Controller
    {

        //_notyf.Success(" تم ادخال المركبة بنجاح  ");
        //_notyf.Success(" تم ادخال المركبة بنجاح",3);
        //_notyf.Error("error");
        //_notyf.Warning("warning");
        //_notyf.Information("informations");
        //_notyf.Custom("custom notification",5,"whitesmoke","fa fa-gear");/* #sdefse or fa fa-home*/
        //var lastRow_FullColumns= _context.TableMv1Vehicles.FirstOrDefault(p => p.IdVehicle == _context.TableMv1Vehicles.Max(x => x.IdVehicle));



        private readonly INotyfService _notyf;

        private readonly MovementDbContext _context;
        public HomeController(MovementDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}





        public IActionResult Index()
        {
            return View();
        }

        //----------------------------------
        public IActionResult VehicleList()
        {

            List<TableMv1Vehicle> vehicles = _context.TableMv1Vehicles.ToList();
            return View(vehicles);
        }
        public IActionResult ViewVehicleDetails(int id)
        {
            TableMv1Vehicle details = _context.TableMv1Vehicles.Where(p => p.IdVehicle == id).FirstOrDefault();

            List<TableMv2StatusVehicleRegister> vehicleLogsList = _context.TableMv2StatusVehicleRegisters.Where(p => p.IdVehicle == id).ToList();

            ViewBag.vehicleLogsList = vehicleLogsList;



            return View(details);
        }
        public ActionResult CreateVehicle()
        {//bring bodyType
         //model.EmployeesList = data.Select(x => new Itemlist { Value = x.EmployeeId, Text = x.EmployeeName }).ToList();
         _notyf.Information("الرجاء مليء جميع الحقول",3);

            var bodyTypeList = _context.RootMv1VehicleBodyTypes.Select(u => u.VehicleBodyName).ToList();
            ViewBag.bodyTypeList = bodyTypeList;

            var bodynamesList = _context.RootMv1VehicleBodyNames.Select(u => u.VehicleBodyName2).ToList();
            ViewBag.bodynamesList = bodynamesList;
            //bring vehicle name
            var vehiclename = _context.RootMv2VehicleNames.Select(u => u.VehicleName).ToList();
            ViewBag.vehiclename = vehiclename;
            //bring wherehouse
            var vehiclWarehouse = _context.RootMv3VehicleWarehouses.Select(u => u.WarehouseName).ToList();
            ViewBag.vehiclWarehouse = vehiclWarehouse;
            //bring vehcle source
            var vehicleSource = _context.RootMv4VehicleSources.Select(u => u.VehicleSource).ToList();
            ViewBag.vehicleSource = vehicleSource;
            //bring individuals
            var individul_fullname = _context.Table1Mains.Where(i => i.Activation == "مستمر").Select(u => u.FullName).ToList();
            ViewBag.individul_fullname = individul_fullname;


            return View();
        }
        [HttpPost]
        public ActionResult CreateVehicle(TableMv1Vehicle CreateVehicleOBJ)
        {



            //if (CreateVehicleOBJ.VinNo == null || CreateVehicleOBJ.VehicleBodyType == null || CreateVehicleOBJ.VehicleBodyName == null ||
            //    CreateVehicleOBJ.VehicleName == null || CreateVehicleOBJ.IdVechicle == null || CreateVehicleOBJ.PlateNumber == null ||
            //    CreateVehicleOBJ.Payload == null || CreateVehicleOBJ.PassengersNo == null || CreateVehicleOBJ.WheelNo == null ||
            //    CreateVehicleOBJ.VehicleModel == null || CreateVehicleOBJ.VehicleBrand == null || CreateVehicleOBJ.VehiclePrice == null ||
            //    CreateVehicleOBJ.VehicleAdministrator == null || CreateVehicleOBJ.DocumentNo == null || CreateVehicleOBJ.DocumentDate == null ||
            //    CreateVehicleOBJ.StatusLastVehicleSource == null || CreateVehicleOBJ.StatusLastVehicleMovement == null || CreateVehicleOBJ.StatusLastVehicle == null ||
            //                    CreateVehicleOBJ.StatusLastVehicleColor == null || CreateVehicleOBJ.StatusLastArmored == null || CreateVehicleOBJ.StatusLastHoursWork == null ||
            //    CreateVehicleOBJ.StatusLastKilometers == null || CreateVehicleOBJ.StatusLastVehicleConsumingRate == null && CreateVehicleOBJ.StatusLastVehicleWarehouse == null
            //    )
            //{
            //_notyf.Custom("حدث خطاء عند ادخال المركبة", 3, "#ff6666");

            //return RedirectToAction("CreateVehicle");

            //}

            //else
            //{
            if (ModelState.IsValid)
            {
                _context.Entry(CreateVehicleOBJ).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
                _notyf.Custom("تم ادخال المركبة بنجاح", 3, "#00cc66", "fa fa-check");

                int id = CreateVehicleOBJ.IdVehicle;
                string VehicleColor = CreateVehicleOBJ.StatusLastVehicleColor.ToString();
                string VehicleArmored = CreateVehicleOBJ.StatusLastArmored.ToString();
                string VehicleHoursWork = CreateVehicleOBJ.StatusLastHoursWork.ToString();
                string VehicleKilometers = CreateVehicleOBJ.StatusLastKilometers.ToString();
                string VehicleConsumingRate = CreateVehicleOBJ.StatusLastVehicleConsumingRate.ToString();
                string VehicleWarehouse = CreateVehicleOBJ.StatusLastVehicleWarehouse.ToString();
                string VehicleSource = CreateVehicleOBJ.StatusLastVehicleSource.ToString();
                string DateAdd = CreateVehicleOBJ.DateAdd.ToString();

                TableMv2StatusVehicleRegister rejester_obj = new TableMv2StatusVehicleRegister();
                rejester_obj.IdVehicle = id;
                rejester_obj.VehicleColor = VehicleColor;
                rejester_obj.VehicleArmored = VehicleArmored;
                rejester_obj.VehicleHoursWork = VehicleHoursWork;
                rejester_obj.VehicleKilometers = VehicleKilometers;
                rejester_obj.VehicleConsumingRate = VehicleConsumingRate;
                rejester_obj.VehicleWarehouse = VehicleWarehouse;
                rejester_obj.VehicleSource = VehicleSource;
                rejester_obj.DateAdd = DateAdd;
                _context.TableMv2StatusVehicleRegisters.AddRange(rejester_obj);
                _context.SaveChanges();

                _notyf.Custom("تم تحديث سجل احداث المركبة بنجاح", 6, "#00cc66", "fa fa-check");

            }
            else
            {
                var bodyTypeList = _context.RootMv1VehicleBodyTypes.Select(u => u.VehicleBodyName).ToList();
                ViewBag.bodyTypeList = bodyTypeList;

                var bodynamesList = _context.RootMv1VehicleBodyNames.Select(u => u.VehicleBodyName2).ToList();
                ViewBag.bodynamesList = bodynamesList;
                //bring vehicle name
                var vehiclename = _context.RootMv2VehicleNames.Select(u => u.VehicleName).ToList();
                ViewBag.vehiclename = vehiclename;
                //bring wherehouse
                var vehiclWarehouse = _context.RootMv3VehicleWarehouses.Select(u => u.WarehouseName).ToList();
                ViewBag.vehiclWarehouse = vehiclWarehouse;
                //bring vehcle source
                var vehicleSource = _context.RootMv4VehicleSources.Select(u => u.VehicleSource).ToList();
                ViewBag.vehicleSource = vehicleSource;
                //bring individuals
                var individul_fullname = _context.Table1Mains.Where(i => i.Activation == "مستمر").Select(u => u.FullName).ToList();
                ViewBag.individul_fullname = individul_fullname;
                _notyf.Custom("حدث خطاء عند ادخال المركبة", 3, "#ff6666");

                _notyf.Custom("حدث خطاء عند تحديث سجل المركبة", 6, "#ff6666");

                return View();


            }
        


            return RedirectToAction("CreateVehicle");
        }
        public ActionResult VehicleEdite(int id)
        {//bring bodyType
         //model.EmployeesList = data.Select(x => new Itemlist { Value = x.EmployeeId, Text = x.EmployeeName }).ToList();

            //TempData["id"] = id;
            TableMv1Vehicle vehicleEditeOBj = _context.TableMv1Vehicles.Where(i => i.IdVehicle == id).FirstOrDefault();




            var bodyTypeList = _context.RootMv1VehicleBodyTypes.Select(u => u.VehicleBodyName).ToList();
            ViewBag.bodyTypeList = bodyTypeList;
            var bodynamesList = _context.RootMv1VehicleBodyNames.Select(u => u.VehicleBodyName2).ToList();
            ViewBag.bodynamesList = bodynamesList;
            //bring vehicle name
            var vehiclename = _context.RootMv2VehicleNames.Select(u => u.VehicleName).ToList();
            ViewBag.vehiclename = vehiclename;
            //bring wherehouse
            var vehiclWarehouse = _context.RootMv3VehicleWarehouses.Select(u => u.WarehouseName).ToList();
            ViewBag.vehiclWarehouse = vehiclWarehouse;
            //bring vehcle source
            var vehicleSource = _context.RootMv4VehicleSources.Select(u => u.VehicleSource).ToList();
            ViewBag.vehicleSource = vehicleSource;
            //bring individuals
            var individul_fullname = _context.Table1Mains.Select(u => u.FullName).ToList();
            ViewBag.individul_fullname = individul_fullname;


            return View(vehicleEditeOBj);
        }
        [HttpPost]
        public ActionResult VehicleEdite(TableMv1Vehicle editeOBJ)
        {
           

 
            if (ModelState.IsValid)
            {
                _context.Attach(editeOBJ);
                _context.Entry(editeOBJ).State = EntityState.Modified;
                _context.SaveChanges();
                _notyf.Custom("تم تعديل المركبة بنجاح", 3, "#00cc66", "fa fa-check");

                int id = editeOBJ.IdVehicle;
                string VehicleColor = editeOBJ.StatusLastVehicleColor.ToString();
                string VehicleArmored = editeOBJ.StatusLastArmored.ToString();
                string VehicleHoursWork = editeOBJ.StatusLastHoursWork.ToString();
                string VehicleKilometers = editeOBJ.StatusLastKilometers.ToString();
                string VehicleConsumingRate = editeOBJ.StatusLastVehicleConsumingRate.ToString();
                string VehicleWarehouse = editeOBJ.StatusLastVehicleWarehouse.ToString();
                string VehicleSource = editeOBJ.StatusLastVehicleSource.ToString();
                string DateAdd = editeOBJ.DateAdd.ToString();

                TableMv2StatusVehicleRegister rejester_obj_edite = new TableMv2StatusVehicleRegister();
                rejester_obj_edite.IdVehicle = id;
                rejester_obj_edite.VehicleColor = VehicleColor;
                rejester_obj_edite.VehicleArmored = VehicleArmored;
                rejester_obj_edite.VehicleHoursWork = VehicleHoursWork;
                rejester_obj_edite.VehicleKilometers = VehicleKilometers;
                rejester_obj_edite.VehicleConsumingRate = VehicleConsumingRate;
                rejester_obj_edite.VehicleWarehouse = VehicleWarehouse;
                rejester_obj_edite.VehicleSource = VehicleSource;
                rejester_obj_edite.DateAdd = DateAdd;
                _context.TableMv2StatusVehicleRegisters.AddRange(rejester_obj_edite);
                _context.SaveChanges();
                _notyf.Custom("تم تحديث سجل احداث المركبة  بنجاح", 6, "#00cc66", "fa fa-check");


            }
            else
            {
           

                var bodyTypeList = _context.RootMv1VehicleBodyTypes.Select(u => u.VehicleBodyName).ToList();
                ViewBag.bodyTypeList = bodyTypeList;

                var bodynamesList = _context.RootMv1VehicleBodyNames.Select(u => u.VehicleBodyName2).ToList();
                ViewBag.bodynamesList = bodynamesList;
                //bring vehicle name
                var vehiclename = _context.RootMv2VehicleNames.Select(u => u.VehicleName).ToList();
                ViewBag.vehiclename = vehiclename;
                //bring wherehouse
                var vehiclWarehouse = _context.RootMv3VehicleWarehouses.Select(u => u.WarehouseName).ToList();
                ViewBag.vehiclWarehouse = vehiclWarehouse;
                //bring vehcle source
                var vehicleSource = _context.RootMv4VehicleSources.Select(u => u.VehicleSource).ToList();
                ViewBag.vehicleSource = vehicleSource;
                //bring individuals
                var individul_fullname = _context.Table1Mains.Where(i => i.Activation == "مستمر").Select(u => u.FullName).ToList();
                ViewBag.individul_fullname = individul_fullname;

                _notyf.Custom("حدث خطاء عند تعديل المركبة", 3, "#ff6666");
                _notyf.Custom("حدث خطاء عند تحديث سجل المركبة", 5, "#ff6666");
                return View();


            }
            

            return RedirectToAction("VehicleList");
        }
        //-----------------------------------------

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
