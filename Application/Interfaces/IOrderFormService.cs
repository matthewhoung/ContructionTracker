using Application.DTOs;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Interfaces
{
    public interface IOrderFormService
    {
        //write section
        Task<int> CreateOrderFormAsync(OrderForm orderForm);
        Task<int> CreatOrderFormDetailAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);

        //read section
        Task<List<OrderForm>> GetAllOrderFormAsync();
        Task<OrderForm> GetOrderFormAsync(int orderFormId);
        Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
        Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId);
        Task<Dictionary<string, int>> GetOrderFormStatusCountAsync();

        //update section

        Task UpdateStatusAsync(int orderFormId);
        Task UpdateIsCheckedAsync(int orderFormId, int userId, bool isChecked);
    }
}
