using ZamowKsiazke.Models;

namespace ZamowKsiazke.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
    }
}
