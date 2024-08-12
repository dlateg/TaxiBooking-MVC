using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Device.Location;
using TaxiBookingApp.Data;
using TaxiBookingApp.Models;

namespace TaxiBookingApp.Controllers
{
    public class DriversController : Controller

    {

        private readonly ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var drivers = await _context.Drivers.ToListAsync();

                return View(drivers);
            }
            catch (Exception ex)
            {
               
                Console.Error.WriteLine(ex);
             
                return View("Error", new ErrorViewModel { RequestId = "Error loading drivers." });
            }
        }

        public async Task<IActionResult> Map()
        {
            try
            {
                ViewBag.Image = Url.Content("~/Images/car.png");
                var drivers = await _context.Drivers.ToListAsync();
                return View(drivers);
            }
            catch (Exception ex)
            {
                
                Console.Error.WriteLine(ex);
                
                return View("Error", new ErrorViewModel { RequestId = "Error loading map." });
            }
        }

        public IActionResult BookingForm()
        {
            return View();
        }

        public IActionResult Book(double latitude, double longitude, string nearestDriverJson)
        
        {
            try
            {
                if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
                {
                    throw new ArgumentOutOfRangeException("Latitude or longitude values are out of range.");
                }

                ViewBag.Image = Url.Content("~/Images/car.png");
                ViewBag.Latitude = latitude;
                ViewBag.Longitude = longitude;
                ViewBag.NearestDriver_json = nearestDriverJson;
                

                return View();
            }
            catch (Exception ex)
            {
                
                Console.Error.WriteLine(ex);
                
                return View("Error", new ErrorViewModel { RequestId = "Error loading booking page." });
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> FindNearestDriver(FormData formData)
        {
            try
            {
                if (formData == null)
                {
                    throw new ArgumentNullException(nameof(formData));
                }

                //using Geordistance to find the nearest driver 
                var drivers = await _context.Drivers.ToListAsync();
                var nearestDriver = drivers.OrderBy(d =>
                    Geodistance(formData.Latitude, formData.Longitude, d.Latitude, d.Longitude)).FirstOrDefault();

                if (nearestDriver == null)
                {
                    throw new InvalidOperationException("No drivers available.");
                }

                return RedirectToAction("Book", new
                {
                    latitude = formData.Latitude,
                    longitude = formData.Longitude,
                    nearestDriverJson = JsonConvert.SerializeObject(nearestDriver)
                    

                });
            }
            catch (Exception ex)
            {
                
                Console.Error.WriteLine(ex);
                
                return View("Error", new ErrorViewModel { RequestId = "Error finding nearest driver." });
            }
        }

        private static double Geodistance(double lat1, double long1, double lat2, double long2)
        {
            try
            {
                if (lat1 < -90 || lat1 > 90 || long1 < -180 || long1 > 180 || lat2 < -90 || lat2 > 90 || long2 < -180 || long2 > 180)
                {
                    throw new ArgumentOutOfRangeException("Latitude or longitude values are out of range.");
                }

                GeoCoordinate customer = new GeoCoordinate(lat1, long1);
                GeoCoordinate taxi = new GeoCoordinate(lat2, long2);

                double distanceInMeters = customer.GetDistanceTo(taxi);
                double distanceInKilometers = distanceInMeters / 1000.0;

                return distanceInKilometers;
            }
            catch (Exception ex)
            {
                
                Console.Error.WriteLine(ex);
              
                throw new InvalidOperationException("Error calculating geodistance.", ex);
            }
        }
    }
}
