namespace Core.Entities.Forms
{
    public class ReceiveForm : OrderForm
    {
        public int ReceiveId { get; set; }
        public bool IsChecked { get; set; } = false;
        public string ReceiveItem { get; set; } = string.Empty;
        public DateTime ReceiveDate { get; set; }
    }
}
