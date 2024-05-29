using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        Task<int> CreateOrderFormAsync(OrderForm orderForm);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<List<OrderForm>> GetAllOrderFormAsync();
        Task<OrderForm> GetOrderFormAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
    }
}
