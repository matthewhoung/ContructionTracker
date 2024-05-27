using Core.Entities.Settings;

namespace Core.Entities.Forms
{
    public class OrderItems : OrderForm
    {
        public int OrderItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public UnitClass UnitClass { get; set; }
        public int TotalPrice { get; set; }
        public bool IsChecked { get; set; }
    }
}
