using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Domain.Entities
{
    public class Airport
    {
        //Airport ID  Unique OpenFlights identifier for this airport.
        //Name Name of airport.May or may not contain the City name.
        //City Main city served by airport. May be spelled differently from Name.
        //Country Country or territory where airport is located.See countries.dat to cross-reference to ISO 3166-1 codes.
        //IATA    3-letter IATA code.Null if not assigned/unknown.
        //ICAO    4-letter ICAO code.Null if not assigned.
        //Latitude Decimal degrees, usually to six significant digits.Negative is South, positive is North.
        //Longitude Decimal degrees, usually to six significant digits.Negative is West, positive is East.
        //Altitude In feet.
        //Timezone Hours offset from UTC.Fractional hours are expressed as decimals, eg.India is 5.5.
        //DST Daylight savings time. One of E (Europe), A (US/Canada), S(South America), O(Australia), Z(New Zealand), N(None) or U(Unknown). See also: Help: Time
        //Tz database time zone Timezone in "tz" (Olson) format, eg. "America/Los_Angeles".
        //Type Type of the airport.Value "airport" for air terminals, "station" for train stations, "port" for ferry terminals and "unknown" if not known.In airports.csv, only type = airport is included.
        //Source Source of this data. "OurAirports" for data sourced from OurAirports, "Legacy" for old data not matched to OurAirports (mostly DAFIF), "User" for unverified user contributions.In airports.csv, only source = OurAirports is included.
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Altitude { get; set; }
        public decimal Timezone { get; set; }
        public string DST { get; set; }
        public string Tz { get; set; }
        public string Type { get; set; }

        public ICollection<Flight> DestinationFlights { get; set; }
        public ICollection<Flight> DepartureFlights { get; set; }
    }
}
