using Core.Entities.Forms.Orders;
using Core.Entities.Forms;
using Core.Entities.Settings;

namespace Application.DTOs
{
    public class OrderFormInfoDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public OrderFormPaymentDto PaymentInfo { get; set; }
        public List<OrderFormStatus> Signatures { get; set; }
        public List<OrderFormWorkers> Workers { get; set; }
    }
}
