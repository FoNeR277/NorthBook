﻿using NorthBook.DataAccess.Repository.IRepository;
using NorthBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthBook.DataAccess.Data;

namespace NorthBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader obj)
        {
            _db?.OrderHeaders?.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {

            var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderFromDb is not null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStatus is not null)
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }
        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {

            var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);

            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentDate = DateTime.Now;
            orderFromDb.PaymentIntentId = paymentIntentId;
        }
    }
}
