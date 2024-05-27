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
        public int WorkerTypeId { get; set; }
        public string WorkerTypeName { get; set; }
        public int WorkerTeamId { get; set; }
        public string WorkerTeamName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int PayAmount { get; set; }
        public int PayTypeId { get; set; }
        public string PayTypeName { get; set; }
        public int PayById { get; set; }
        public string PayByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
