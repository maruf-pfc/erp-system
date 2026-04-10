using AutoMapper;
using ERP.Application.Features.HR.DTOs;
using ERP.Application.Interfaces;
using ERP.Application.Wrappers;
using ERP.Domain.Entities.HR;
using MediatR;

namespace ERP.Application.Features.HR.Queries.GetEmployees;

public class GetEmployeesQueryHandler
    : IRequestHandler<GetEmployeesQuery, PaginatedResponse<EmployeeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<EmployeeDto>> Handle(
        GetEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.Repository<Employee>().GetAllAsync();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLower();
            employees = employees.Where(e =>
                e.FirstName.ToLower().Contains(search) ||
                e.LastName.ToLower().Contains(search) ||
                e.Email.ToLower().Contains(search));
        }

        var totalCount = employees.Count();
        var paged = employees
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        return new PaginatedResponse<EmployeeDto>
        {
            Data = _mapper.Map<List<EmployeeDto>>(paged),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}