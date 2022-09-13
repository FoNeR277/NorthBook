using NorthBook.DataAccess.Repository.IRepository;
using NorthBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthBook.DataAccess.Data;

namespace NorthBook.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            return shoppingCart.Count += count;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            return shoppingCart.Count -= count;
        }
    }
}
