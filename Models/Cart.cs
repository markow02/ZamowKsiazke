using ZamowKsiazke.Data;

namespace ZamowKsiazke.Models
{
    public class Cart
    {
        private readonly ZamowKsiazkeContext _context;

        public Cart(ZamowKsiazkeContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ZamowKsiazkeContext>();
            string cartId = session.GetString(key: "Id") ?? Guid.NewGuid().ToString();

            session.SetString(key: "Id", cartId);

            return new Cart(context) { Id = cartId };
        }
    }
}
