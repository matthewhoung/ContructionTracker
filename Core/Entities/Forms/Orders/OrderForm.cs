namespace Core.Entities.Forms.Orders
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}