using ERP.Application.Wrappers;
using MediatR;

namespace ERP.Application.Features.HR.Commands.CreateEmployee;

public record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Department,
    string Position,
    decimal Salary,
    DateTime JoinDate
) : IRequest<ApiResponse<Guid>>;