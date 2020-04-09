using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Mappers
{
    public static class AutoMapperConfig // odpowiada nza konfigurację.
    {
        public static IMapper Initialize() //Zwróci nam instanc ję interfejsu Mapper

            => new MapperConfiguration(cfg =>  //IMaper-interfejs , Initialize-Metoda(która zwraca implementacje tego interfejsu), 

        {                                       //Dostarczamy konfigurację do Mappera w postaci wyrażenia lambda
            cfg.CreateMap<Driver, DriverDto>();
            cfg.CreateMap<Driver, DriverDetailsDto>();
            cfg.CreateMap<Node, NodeDto>();
            cfg.CreateMap<Route, RouteDto>();
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Vehicle, VehicleDto>();
        })
            .CreateMapper();                //metoda CreateMapper na podstawie konfiguracji tworzzy interfejs IMaper
        
    }
}
