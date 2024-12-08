using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamowKsiazke.Models;

namespace ZamowKsiazke.Data
{
    public class ZamowKsiazkeContext : DbContext
    {
        public ZamowKsiazkeContext(DbContextOptions<ZamowKsiazkeContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
    }
}
