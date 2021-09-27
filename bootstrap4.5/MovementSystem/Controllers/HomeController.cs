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



        private readonly INotyfService _notyf;

        private readonly MovementDbContext  _context;
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
        public IActionResult ViewVehicleDetails(int id )
        {
            TableMv1Vehicle details = _context.TableMv1Vehicles.Where(p => p.IdVehicle == id).FirstOrDefault();

          List<TableMv2StatusVehicleRegister>  vehicleLogsList = _context.TableMv2StatusVehicleRegisters.Where(p => p.IdVehicle == id).ToList();
            ViewBag.vehicleLogsList = vehicleLogsList;


             
            return View(details);
        }
        public ActionResult CreateVehicle()
        {//bring bodyType
            //model.EmployeesList = data.Select(x => new Itemlist { Value = x.EmployeeId, Text = x.EmployeeName }).ToList();

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
            var individul_fullname = _context.Table1Mains.Where(i=>i.Activation=="مستمر").Select(u => u.FullName).ToList();
            ViewBag.individul_fullname = individul_fullname;


            return View();
        }
        [HttpPost]
        public ActionResult CreateVehicle(TableMv1Vehicle CreateVehicleOBJ)
        {
            _context.Entry(CreateVehicleOBJ).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();


            _notyf.Success("      تم ادخال المركبة بنجاح      ");
            _notyf.Success(" تم ادخال المركبة بنجاح",3);
            _notyf.Error("error");
            _notyf.Warning("warning");
            _notyf.Information("informations");
            _notyf.Custom("custom notification",5,"whitesmoke","fa fa-gear");/* #sdefse or fa fa-home*/
            //var lastRow_FullColumns= _context.TableMv1Vehicles.FirstOrDefault(p => p.IdVehicle == _context.TableMv1Vehicles.Max(x => x.IdVehicle));

            //int _lastid = Convert.ToInt32(lastID);

            var lastID = _context.TableMv1Vehicles.Max(x => x.IdVehicle);
            int _lastID = Convert.ToInt32(lastID);

            List<TableMv2StatusVehicleRegister> _List = (from p in _context.TableMv1Vehicles.AsEnumerable().Where(p => p.IdVehicle == _lastID)
                                                        select new TableMv2StatusVehicleRegister
                                                        {
                                                            IdVehicle = p.IdVehicle,
                                                            VehicleColor = p.StatusLastVehicleColor.ToString(),
                                                            VehicleArmored = p.StatusLastArmored.ToString(),
                                                            VehicleHoursWork = p.StatusLastHoursWork.ToString(),
                                                            VehicleKilometers = p.StatusLastKilometers.ToString(),
                                                            VehicleConsumingRate = p.StatusLastVehicleConsumingRate.ToString(),
                                                            VehicleWarehouse = p.StatusLastVehicleWarehouse.ToString(),
                                                            VehicleSource = p.StatusLastVehicleSource.ToString(),
                                                            DateAdd = p.DateAdd.ToString()

                                                        }).ToList();
            _context.TableMv2StatusVehicleRegisters.AddRange(_List);
            _context.SaveChanges();

            return RedirectToAction("CreateVehicle");
        }
        public ActionResult VehicleEdite(int id)
        {//bring bodyType
         //model.EmployeesList = data.Select(x => new Itemlist { Value = x.EmployeeId, Text = x.EmployeeName }).ToList();

           TempData["id"] = id;
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
        public ActionResult VehicleEdite( TableMv1Vehicle editeOBJ)
        {
            int s = Convert.ToInt32(TempData["id"].ToString());

            _context.Attach(editeOBJ);
            _context.Entry(editeOBJ).State = EntityState.Modified;
            _context.SaveChanges();
            //insert to log table 

            //TableMv1Vehicle select_last_row_obj = _context.TableMv1Vehicles.Where(p => p.IdVehicle == ).Select

             //var  liste = _context.TableMv1Vehicles.Where(i => i.IdVehicle == s).Select(x => new { x.IdVehicle, x.StatusLastVehicleColor, x.StatusLastArmored, x.StatusLastHoursWork, x.StatusLastKilometers, x.StatusLastVehicleConsumingRate, x.StatusLastVehicleWarehouse, x.StatusLastVehicleSource, x.DateAdd }).ToList();

            List<TableMv2StatusVehicleRegister> List = (from p in _context.TableMv1Vehicles.AsEnumerable().Where(p => p.IdVehicle == s)
                                                        select new TableMv2StatusVehicleRegister
                                                 {
                                                     IdVehicle = p.IdVehicle,
                                                     VehicleColor = p.StatusLastVehicleColor.ToString(),
                                                     VehicleArmored = p.StatusLastArmored.ToString(),
                                                     VehicleHoursWork = p.StatusLastHoursWork.ToString(),
                                                     VehicleKilometers = p.StatusLastKilometers.ToString(),
                                                     VehicleConsumingRate = p.StatusLastVehicleConsumingRate.ToString(),
                                                     VehicleWarehouse = p.StatusLastVehicleWarehouse.ToString(),
                                                       VehicleSource = p.StatusLastVehicleSource.ToString(),
                                                     DateAdd = p.DateAdd.ToString()

                                                        }).ToList();
            _context.TableMv2StatusVehicleRegisters.AddRange(List);
            //var addedEntities = _context.ChangeTracker.Entries()
            //        .Any(x => x.State == EntityState.Added);


            _context.SaveChanges();


            return  RedirectToAction("VehicleList");
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
