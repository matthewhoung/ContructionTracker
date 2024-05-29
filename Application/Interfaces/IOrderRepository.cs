using Application.DTOs;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Application
{
    public interface IOrderRepository
    {
        //write section
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderItemAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);

        //read section
        Task<List<OrderForm>> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
        Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId);

        //todo
        Task<IReadOnlyList<PayBy>> GetPayByAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
    }
}
