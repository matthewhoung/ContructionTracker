namespace Core.Entities.Forms.Orders
{
    public class OrderFormCheckList
    {
        public int CheckId { get; set; }
        public int OrderFormId { get; set; }
        public int OrderRoleId { get; set; }
        public int UserId { get; set; }
        public bool isChecked { get; set; } = false;
    }
}
