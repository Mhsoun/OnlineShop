using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingtipToys.Models;

namespace MyShop.DataAcces.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }


    }
}
