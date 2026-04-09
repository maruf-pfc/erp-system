using ERP.Domain.Common;
using ERP.Domain.Enums;

namespace ERP.Domain.Entities.HR;

public class Employee : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime JoinDate { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
}