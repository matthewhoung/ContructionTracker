using Core.Entities.Settings;

namespace Core.Entities.Forms
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public bool CreatorChecked { get; set; }
        public int SupervisorId { get; set; }
        public bool SupervisorChecked { get; set; }
        public int DirectorId { get; set; }
        public bool DirectorChecked { get; set; }
        public int ProjectId { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public WorkerType WorkerType { get; set; }
        public WorkerTeam WorkerTeam { get; set; }
        public Department Department { get; set; }
        public int PayAmount { get; set; }
        public PayType PayType { get; set; }
        public PayBy PayBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
