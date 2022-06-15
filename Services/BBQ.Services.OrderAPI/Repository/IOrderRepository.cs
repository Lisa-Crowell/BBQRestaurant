using BBQ.Services.OrderAPI.Models;

namespace BBQ.Services.OrderAPI.Repository;

public interface IOrderRepository
{
    Task<bool> AddOrder(OrderHeader orderHeader);
    Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
}