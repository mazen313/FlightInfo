using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Interfaces.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
