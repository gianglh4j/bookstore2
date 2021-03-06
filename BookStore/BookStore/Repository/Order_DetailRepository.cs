﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public interface IOrder_DetailRepository
    {
        Task<IEnumerable<OrderBDetail>> GetOrderB_Details();
        Task<OrderBDetail> GetOrderB_Detail(int OrderB_DetailId);
        Task<OrderBDetail> AddOrderB_Detail(OrderBDetail orderB_Detail);
        Task<OrderBDetail> UpdateOrderB_Detail(OrderBDetail OrderB_Detail);
        Task DeleteOrderB_Detail(int OrderB_DetailId);

    }
    public class Order_DetailRepository : IOrder_DetailRepository
    {
        private readonly BookStoredbContext bookStoredbContext;
        public Order_DetailRepository(BookStoredbContext bookStoredbContext)
        {
            this.bookStoredbContext = bookStoredbContext;

        }
        public async Task<OrderBDetail> AddOrderB_Detail(OrderBDetail orderB_Detail)
        {
            var result = await bookStoredbContext.OrderBDetail.AddAsync(orderB_Detail);
            try
            {
                await bookStoredbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return result.Entity;
        }

        public async Task DeleteOrderB_Detail(int OrderId)
        {
            //remove order-details  
            var OrderB_Details = await bookStoredbContext.OrderBDetail.Where(e => e.OrderId == OrderId).ToListAsync();
            bookStoredbContext.OrderBDetail.RemoveRange(OrderB_Details);
            await bookStoredbContext.SaveChangesAsync();
        }

        public Task<OrderBDetail> GetOrderB_Detail(int OrderB_DetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderBDetail>> GetOrderB_Details()
        {
            throw new NotImplementedException();
        }

        public Task<OrderBDetail> UpdateOrderB_Detail(OrderBDetail OrderB_Detail)
        {
            throw new NotImplementedException();
        }
    }
}
