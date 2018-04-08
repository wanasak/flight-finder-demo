using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FlightFinder.Server.Controllers
{
    [Route("api/[controller]")]
    public class FlightSearchController : Controller
    {
        public async Task<IEnumerable<Itinery>> Search([FromBody] SearchCriteria criteria)
        {
            await Task.Delay(500);  // FAKE

            var random = new Random();
            return Enumerable.Range(0, random.Next(1, 5)).Select(_ => new Itinery
            {
                Price = random.Next(100, 2000),
                Outbound = new FlightSegment
                {
                    Airline = RandomAirline(),
                    FromAirportCode = criteria.FromAirport,
                    ToAirportCode = criteria.ToAirport,
                    DepartureTime = criteria.OutboundDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                    ArrivalTime = criteria.OutboundDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                    DurationHours = 2 + random.Next(10),
                    TicketClass = criteria.TicketClass
                },
                Return = new FlightSegment
                {
                    Airline = RandomAirline(),
                    FromAirportCode = criteria.ToAirport,
                    ToAirportCode = criteria.FromAirport,
                    DepartureTime = criteria.ReturnDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                    ArrivalTime = criteria.ReturnDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                    DurationHours = 2 + random.Next(10),
                    TicketClass = criteria.TicketClass
                }
            });
        }

        private string RandomAirline() => SampleData.Airlines[new Random().Next(SampleData.Airlines.Length)];
    }
}