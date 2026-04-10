using ERP.Application.Interfaces;
using ERP.Application.Wrappers;
using ERP.Domain.Entities.HR;
using MediatR;

namespace ERP.Application.Features.HR.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, ApiResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<Guid>> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Department = request.Department,
            Position = request.Position,
            Salary = request.Salary,
            JoinDate = request.JoinDate,
            CreatedBy = "system" // will be replaced with current user later
        };

        await _unitOfWork.Repository<Employee>().AddAsync(employee);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse<Guid>.Success(employee.Id, "Employee created successfully");
    }
}