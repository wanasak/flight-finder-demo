using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FlightFinder.Server.Controllers
{
    [Route("api/[controller]")]
    public class AirportsController : Controller
    {
        public  IEnumerable<Airport> Airports()
        {
            return SampleData.Airports;
        }
    }
}