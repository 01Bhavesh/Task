using New_CRUDTask.Model;
using New_CRUDTask.Model.DTO;

namespace New_CRUDTask.IServiceImplementation
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders(int page, int pageSize);
        Order? GetOrderById(int id);
        Task<bool> CreateOrder(OrderCreatedDTO order);
        Task<bool> UpdateOrder(OrderCreatedDTO order);
        Task<bool> DeleteOrder(int d);
        Task<List<OrderDTO>> GetOrdersByUserId(int userId);
    }
}
