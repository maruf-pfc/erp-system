using ERP.Domain.Common;
using ERP.Domain.Enums;

namespace ERP.Domain.Entities.Procurement;

public class PurchaseOrder : AuditableEntity
{
    public string PONumber { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public DateTime ExpectedDelivery { get; set; }
    public decimal TotalAmount { get; set; }
    public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Pending;
}