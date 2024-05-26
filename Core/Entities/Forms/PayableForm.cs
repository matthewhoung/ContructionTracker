using Core.Entities.Enums;

namespace Core.Entities.Forms
{
    public class PayableForm : ReceiveForm
    {
        public int Id { get; set; }
        public PayType PayType { get; set; }
        public int PayAmount { get; set; }
        public DateTime PayMentDue { get; set; }
    }
}
