using Microsoft.AspNetCore.Mvc;
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




        private readonly MovementDbContext  _context;
        public HomeController(MovementDbContext context)
        {
            _context = context;
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
        {

             return View();
        }
        [HttpPost]
        public ActionResult CreateVehicle(TableMv1Vehicle CreateVehicleOBJ)
        {
            _context.Entry(CreateVehicleOBJ).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return View();
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
