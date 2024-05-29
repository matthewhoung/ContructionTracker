using Application.DTOs;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Application
{
    //TODO:
    /*
     * 單據狀態(checklist => status => pending, processing, completed)
     * 組裝採購單(Order + detail + workerlist + payinfo + status)
     */
    public interface IOrderRepository
    {
        //write section
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderDetailAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);

        //read section
        Task<List<OrderForm>> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int orderFormId);
        Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
        Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId);
    }
}
