using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaxiBookingApp.Models;

namespace TaxiBookingApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any drivers.
                if (context.Drivers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Drivers.AddRange(
                    new Driver
                    {
                        VehicleId = "mXfkjrFw",
                        Latitude = 51.5090562,
                        Longitude = -0.1304571,
                        Place = ""
                    },
                    new Driver
                    {
                        VehicleId = "nZXB8ZHz",
                        Latitude = 51.5080898,
                        Longitude = -0.07620836346036469,
                        Place = "Tower of London"
                    },
                    new Driver
                    {
                         VehicleId = "Tkwu74WC",
                         Latitude = 51.5425649,
                         Longitude = -0.00693080308689057,
                         Place = "Westfield Stratford City",
                    },
                    new Driver
                    {
                         VehicleId = "5KWpnAJN",
                         Latitude = 51.519821199999996,
                         Longitude = -0.09397523701275332,
                         Place = "The Barbican Centre",
                     },
                     new Driver
                     {
                         VehicleId = "uf5ZrXYw",
                         Latitude = 51.5133798,
                         Longitude = -0.0889552,
                         Place = "The Bank of England",
                     },
                     new Driver
                     {
                         VehicleId = "VMerzMH8",
                         Latitude = 51.5253378,
                         Longitude = -0.033435,
                         Place = "ile End Station",
                     },
                     new Driver
                     {
                         VehicleId = "8efT67Xd",
                         Latitude = 51.54458615,
                         Longitude = -0.0161905117168855,
                         Place = "Queen Elizabeth Olympic Park",
                     }





                );

                context.SaveChanges();
            }
        }
    }
}
