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
        Task<int> CreatOrderFormDetailAsync(OrderFormDetail orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);
        Task<int> CreatOrderFormDepartmentAsync(OrderFormDepartment department);

        //Read Section
        Task<List<OrderForm>> GetAllOrderFormAsync();
        Task<OrderFormInfoDto> GetOrderFormAsync(int orderFormId);
        Task<List<OrderFormInfoDto>> GetOrderByUserAsync(int userId);
        Task<List<OrderFormDetail>> GetOrderDetailAsync(int orderFormId);
        Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId);
        Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId);
        Task<List<OrderFormDepartmentDto>> GetOrderFormDepartmentAsync(int orderFormId);
        Task<Dictionary<string, int>> GetOrderFormStatusCountAsync();
        Task<int> GetOrderFormStatus(int orderfromId);

        //Update Section

        Task UpdateOrderDetailAsync(OrderFormDetail orderItems);
        Task UpdateOrderFormPayInfoAsync(OrderFormPayInfo paymentInfo);
        Task UpdateWorkerAsync(OrderFromWorkerDto workerList);
        Task UpdateStatusAsync(int orderFormId);
        Task UpdateSignatureAsync(int orderFormId, int userId, bool isChecked);

        //Delete Section

        Task DeleteOrderDetailAsync(int orderformId);
    }
}
