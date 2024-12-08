using Microsoft.EntityFrameworkCore;
using ZamowKsiazke.Data;
using ZamowKsiazke.Models;
using ZamowKsiazke.Services.Interfaces;
using System.Threading.Tasks;


namespace ZamowKsiazke.Services
{
    public class OrderService : IOrderService
    {
        private readonly ZamowKsiazkeContext _context;

        public OrderService(ZamowKsiazkeContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} not found.");
            }

            return order;
        }
    }
}
