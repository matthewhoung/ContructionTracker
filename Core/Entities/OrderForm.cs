namespace Core.Entities
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public string WorkerType { get; set; }
        public string WorkerTeam { get; set; }
        public string Department { get; set; }
        public decimal PayAmount { get; set; }
        public string PayType { get; set; }
    }
}
