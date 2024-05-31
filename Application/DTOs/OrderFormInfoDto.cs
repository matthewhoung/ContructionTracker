using Core.Entities.Forms.Orders;
using Core.Entities.Forms;
using Core.Entities.Settings;
using Core.Entities.Settings.Uploader;

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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderFormDetail> OrderItems { get; set; }
        public List<OrderFormWorker> Workers { get; set; }
        public OrderFormPayInfo PaymentInfo { get; set; }
        public List<OrderFormDepartment> Department { get; set; }
        public List<OrderFormStatus> Signatures { get; set; }
        public List<FileUploaderPath> FilePaths { get; set; }
    }
}
