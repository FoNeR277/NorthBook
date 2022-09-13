using NorthBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthBook.DataAccess.Data;

namespace NorthBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext? _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType {  get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public void Save()
        {
            _db?.SaveChanges();
        }
    }
}
