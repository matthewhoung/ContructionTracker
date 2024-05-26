using Core.Entities.Enums;

namespace Core.Entities.Forms
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public WorkerType WorkerType { get; set; }
        public string WorkerTeam { get; set; }
        public string Department { get; set; }
        public decimal PayAmount { get; set; }
        public PayType PayType { get; set; }
    }
}
