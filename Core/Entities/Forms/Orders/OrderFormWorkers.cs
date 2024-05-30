namespace Core.Entities.Forms.Orders
{
    public class OrderFormWorkers
    {
        public int OrderId { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int WorkerTypeId { get; set; }
        public string WorkerTypeName { get; set; }
        public int WorkerTeamId { get; set; }
        public string WorkerTeamName { get; set; }
    }
}
