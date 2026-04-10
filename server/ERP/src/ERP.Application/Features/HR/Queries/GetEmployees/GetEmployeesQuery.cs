using ERP.Application.Features.HR.DTOs;
using ERP.Application.Wrappers;
using MediatR;

namespace ERP.Application.Features.HR.Queries.GetEmployees;

public record GetEmployeesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string? Search = null
) : IRequest<PaginatedResponse<EmployeeDto>>;