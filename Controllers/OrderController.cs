using Microsoft.AspNetCore.Mvc;
using ZamowKsiazke.Data;
using ZamowKsiazke.Models;
using ZamowKsiazke.Services.Interfaces;

namespace ZamowKsiazke.Controllers
{
    public class OrderController : Controller
    {
        private readonly ZamowKsiazkeContext _context;
        private readonly Cart _cart;
        private readonly IOrderService _orderService;

        public OrderController(ZamowKsiazkeContext context, Cart cart, IOrderService orderService)
        {
            _context = context;
            _cart = cart;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Twój koszyk jest pusty, dodaj książki by kontynuować");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return RedirectToAction("CheckoutComplete", new { orderId = order.Id });
            }

            return View(order);
        }

        public async Task<IActionResult> CheckoutComplete(int orderId)
        {
            var order = await _orderService.GetOrderWithItemsAsync(orderId);
            return View(order);
        }

        private void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var cartItems = _cart.CartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Price = item.Book.Price * item.Quantity
                };

                order.OrderItems.Add(orderItem);
                order.OrderTotal += orderItem.Price;
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
