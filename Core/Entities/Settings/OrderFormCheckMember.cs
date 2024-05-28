namespace Core.Entities.Settings
{
    public class OrderFormCheckMember
    {
        public int CheckId { get; set; }
        public int OrderFormId { get; set; }
        public int OrderRoleId { get; set; }
        public bool isChecked { get; set; } = false;
    }
}
