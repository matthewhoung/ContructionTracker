using Application.DTOs;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Interfaces
{
    public interface IOrderFormService
    {
        //Create Section
        Task<int> CreateOrderFormAsync(OrderForm orderForm);
        Task<int> CreatOrderFormDetailAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);

        //Read Section
        Task<List<OrderForm>> GetAllOrderFormAsync();
        Task<OrderFormInfoDto> GetOrderFormAsync(int orderFormId);
        Task<List<OrderFormInfoDto>> GetOrderByUserAsync(int userId);
        Task<List<OrderItems>> GetOrderDetailAsync(int orderFormId);
        Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId);
        Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId);
        Task<Dictionary<string, int>> GetOrderFormStatusCountAsync();
        Task<int> GetOrderFormStatus(int orderfromId);

        //Update Section

        Task UpdateStatusAsync(int orderFormId);
        Task UpdateSignatureAsync(int orderFormId, int userId, bool isChecked);

        //Delete Section

        Task DeleteOrderDetailAsync(int orderformId);
    }
}
