using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    public class OnlineShoppingContext: DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<Orderdetail> Orderdetails { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductInfo> ProductInfos { get; set; }

        public DbSet<Type> Types { get; set; }

        public DbSet<UserInfor> UserInfors { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<VipRank> VipRanks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=OnlineShopping;User ID=sa;Password=123456");
        }
    }
}
