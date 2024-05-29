namespace Core.Entities.Forms
{
    public class OrderItems
    {
        public int DetailId { get; set; }
        public int OrderItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int UnitNameId { get; set; }
        public int TotalPrice { get; set; }
        public bool IsChecked { get; set; }
    }
}
