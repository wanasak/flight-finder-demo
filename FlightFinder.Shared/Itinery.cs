using System;
using System.Collections.Generic;
using System.Text;

namespace FlightFinder.Shared
{
    public class Itinery
    {
        public FlightSegment Outbound { get; set; }
        public FlightSegment Return { get; set; }
        public decimal Price { get; set; }

        public double TotalDurationHours => Outbound.DurationHours + Return.DurationHours;

        public string AirlineName => (Outbound.Airline == Return.Airline) ? Outbound.Airline : "Multiple Airlines";
    }
}
