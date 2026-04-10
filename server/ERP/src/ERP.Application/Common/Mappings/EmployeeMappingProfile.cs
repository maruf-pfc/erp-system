using AutoMapper;
using ERP.Application.Features.HR.DTOs;
using ERP.Domain.Entities.HR;

namespace ERP.Application.Common.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString()));
    }
}