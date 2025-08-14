using AutoMapper;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Application.DTOs.Mechanic;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Application.DTOs.Vehicle;
using CarRepairShop.Domain.Entities;

namespace CarRepairShop.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerEntity, CustomerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                src.Name.FirstName + " " + src.Name.LastName))
            .ForMember(dest => dest.Vehicles, opt =>
                opt.MapFrom(src => src.Vehicles));

        CreateMap<VehicleEntity, VehicleSummaryDto>()
            .ForMember(dest => dest.LicensePlateNumber, opt =>
                opt.MapFrom(src => src.LicensePlate.Value));

        CreateMap<VehicleEntity, VehicleDto>()
            .ForMember(dest => dest.LicensePlateNumber, opt =>
                opt.MapFrom(src => src.LicensePlate.Value))
            .ForMember(dest => dest.CustomerId, opt =>
                opt.MapFrom(src => src.CustomerId));

        CreateMap<MechanicEntity, MechanicDto>()
            .ForMember(dest => dest.FullName, opt =>
                opt.MapFrom(src => src.Name.FirstName + " " + src.Name.LastName));

        CreateMap<RepairOrderEntity, RepairOrderDto>()
            .ForMember(dest => dest.RepairCost, opt =>
                opt.MapFrom(src => src.RepairCost.Amount))
            .ForMember(dest => dest.RepairCostCurrency, opt =>
                opt.MapFrom(src => src.RepairCost.Currency))
            .ForMember(dest => dest.Vehicle, opt =>
                opt.MapFrom(src => src.Vehicle))
            .ForMember(dest => dest.Mechanic, opt =>
                opt.MapFrom(src => src.Mechanic));
    }
}