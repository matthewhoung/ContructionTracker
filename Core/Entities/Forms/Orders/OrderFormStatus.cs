namespace Core.Entities.Settings
{
    public class OrderFormStatus
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public bool isChecked { get; set; }
    }
}
