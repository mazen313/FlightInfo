using AutoMapper;
using FlightInfo.Application.Interfaces.Mapping;
using FlightInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Flights.Queries
{
    public class AirportSearchModel
    {
        public IList<AirportSearchLookupModel> Airports { get; set; }
    }
    public class AirportSearchLookupModel : IHaveCustomMapping
    {
        public int AirportId { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Airport, AirportSearchLookupModel>()
                .ForMember(cDTO => cDTO.AirportId, opt => opt.MapFrom(c => c.AirportId))
                .ForMember(cDTO => cDTO.Latitude, opt => opt.MapFrom(c => c.Latitude))
                .ForMember(cDTO => cDTO.Longitude, opt => opt.MapFrom(c => c.Longitude))
                .ForMember(cDTO => cDTO.Description, opt => opt.MapFrom(c => string.Format("{0} - {1} {2}", c.Name, c.City, c.Country)));
        }
    }
}
