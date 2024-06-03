using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Application
{
    //TODO:
    /* 
     * 新增創建功能:
     * 新增取得功能: 取得待使用者簽核的訂單，取得各狀態的訂單
     * 新增更新功能: 
     * 新增刪除功能: 
     */
    public interface IOrderFormRepository
    {
        //Create Section
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderDetailAsync(OrderFormDetail orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        Task<int> CreateOrderFormWorkerList(OrderFormWorker workerList);
        Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo);
        Task<int> CreatOrderFormDepartmentAsync(OrderFormDepartment department);

        //Read Section
        Task<List<OrderForm>> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int orderFormId);
        Task<List<OrderForm>> GetOrderByUserAsync(int userId);
        Task<List<OrderFormDetail>> GetOrderDetailAsync(int orderFormId);
        Task<int> GetSumDetailTotalPriceAsync(int orderFormId);
        Task<OrderFormPayInfo> GetOrderFormPayInfoAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId);
        Task<List<OrderFormWorker>> GetOrderFormWorkerAsync(int orderFormId);
        Task<List<OrderFormDepartment>> GetOrderFormDepartmentAsync(int orderFormId);
        Task<Dictionary<string, int>> GetOrderFormStatusCountAsync();
        Task<string> GetOrderFormStatus(int orderfromId);

        //Update Section

        Task UpdateOrderDetailAsync(OrderFormDetail orderItems);
        Task UpdateOrderDetailTotalPriceAsync(int orderFormId);
        Task UpdateOrderFormPayInfoAsync(OrderFormPayInfo paymentInfo);
        Task UpdateOrderFormPayinfoAmountAsync(int orderFormId);
        Task UpdateWorkerAsync(OrderFormWorker workerList);
        Task UpdateStatusAsync(int orderFormId);
        Task UpdateSignatureAsync(int orderFormId, int userId, bool isChecked);

        //Delete Section

        Task DeleteOrderDetailAsync(int orderformId);
    }
}
