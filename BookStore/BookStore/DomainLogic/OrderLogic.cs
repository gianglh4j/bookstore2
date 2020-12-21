using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DTO;
using BookStore.Models;
using BookStore.Repository;

namespace BookStore.DomainLogic
{
  
    public interface IOrderLogic
    {
        Task<OrderB> AddOrder(OrderB order);
        Task<OrderB> UpdateOrder(OrderB order);
        Task<OrderB> getOrder(int orderId);

        Task<IEnumerable<OrderB>> getOrders();


    }
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrder_DetailRepository _order_DetailRepository;

        public OrderLogic(IOrderRepository orderRepository, IOrder_DetailRepository order_DetailRepository)
        {
            this._orderRepository = orderRepository;
            this._order_DetailRepository = order_DetailRepository;

        }

        public async Task<OrderB> AddOrder(OrderB order)
        {
            
            var result = await _orderRepository.AddOrder(order);
            return result;
        }

        public async Task<OrderB> getOrder(int orderId)
        {
            var result = await _orderRepository.GetOrder(orderId);
            return result;
        }

        public async Task<IEnumerable<OrderB>> getOrders()
        {
            var result = await _orderRepository.GetOrders();
            return result;
        }

        public async Task<OrderB> UpdateOrder(OrderB order)
        {
            //if (order.OrderBDetail != null)
            //{
            //    //remove last book_bookType 
            //    await _order_DetailRepository.DeleteOrderB_Detail(order.OrderId);

            //}
            var result = await _orderRepository.UpdateOrder(order);

            return result;
          

        }

    }
}

