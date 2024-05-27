using Core.Entities.Forms;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        Task<int> CreateOrderFormAsync(OrderForm orderForm);
    }
}
