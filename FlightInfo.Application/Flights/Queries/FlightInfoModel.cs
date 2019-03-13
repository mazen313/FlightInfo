using AutoMapper;
using FlightInfo.Application.Interfaces.Mapping;
using FlightInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.FlightInfo
{
   

    public class FlightInfoModel
    {
        public IList<FlightInfoLookupModel> Data { get; set; }
        public int TotalRows { get; set; }
    }
    public class FlightInfoLookupModel : IHaveCustomMapping
    {
        public Guid ID { get; set; }
        public string DepartureAirport { get; set; }
        public int DepartureAirportId { get; set; }
        public string DestinationAirport { get; set; }
        public int DestinationAirportId { get; set; }
        public decimal FuelConsumption { get; set; }
        public double Distance { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Flight, FlightInfoLookupModel>()
              .ForMember(cDTO => cDTO.ID, opt => opt.MapFrom(c => Guid.NewGuid()))
              .ForMember(cDTO => cDTO.DepartureAirportId, opt => opt.MapFrom(c => c.DepartureAirportId))
              .ForMember(cDTO => cDTO.DestinationAirportId, opt => opt.MapFrom(c => c.DestinationAirportId))
              .ForMember(cDTO => cDTO.DepartureAirport, opt => opt.MapFrom(c => c.DepartureAirport.Name))
              .ForMember(cDTO => cDTO.DestinationAirport, opt => opt.MapFrom(c => c.DestinationAirport.Name))
              .ForMember(cDTO => cDTO.FuelConsumption, opt => opt.MapFrom(c => c.FuelConsumption))
              .ForMember(cDTO => cDTO.Distance, opt => opt.MapFrom(c => c.Distance));
        }
    }
}
