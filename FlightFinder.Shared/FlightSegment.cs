﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlightFinder.Shared
{
    public class FlightSegment
    {
        public string Airline { get; set; }
        public string FromAirportCode { get; set; }
        public string ToAirportCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double DurationHours { get; set; }
        public TicketClass TicketClass { get; set; }
    }
}
