using Application.DTOs;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Application
{
    //TODO:
    /*
     * 新增取得功能: 組裝採購單(Order + detail + workerlist + payinfo + status)
     * 新增創建功能: 
     * 新增更新功能: 單據名稱、單據說明、付款方式、工種廠商、簽核(退簽)
     * 新增刪除功能: 
     * 
     */
    public interface IOrderFormRepository
    {
        //Create Section
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderDetailAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);

        //Read Section
        Task<List<OrderForm>> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int orderFormId);
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
