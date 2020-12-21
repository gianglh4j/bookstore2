using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.DTO;
using AutoMapper;
using BookStore.DomainLogic;

namespace BookStore.ApplicationLogic
{

    public interface IOrderApplicationLogics
    {
     

        Task<OrderB> addOrder(OrderDTO orderDTO);

        Task<OrderB> updateOrderB(OrderDTO orderDTO);

        Task<IEnumerable<OrderDTOres>> getOrders();

        Task<OrderDTOres> getOder(int orderId);

    }

    public class OrderApplicationLogics : IOrderApplicationLogics
    {
        private readonly IMapper mapper;
        private readonly  IOrderLogic _orderLogic;
        public OrderApplicationLogics(IMapper mapper, IOrderLogic orderLogic)
        {
            this.mapper = mapper;
            this._orderLogic = orderLogic;
        }

        public async Task<OrderB> addOrder(OrderDTO orderDTO)
        {
            OrderB newOrderB = mapper.Map<OrderB>(orderDTO);
           return  await _orderLogic.AddOrder(newOrderB);


        }

        public async Task<OrderDTOres> getOder(int orderId)
        {
            var order = await _orderLogic.getOrder(orderId);
            var destinations = mapper.Map<OrderB, OrderDTOres>(order);
            return destinations;
        }

        public async Task<IEnumerable<OrderDTOres>> getOrders()
        {
            var orders = await _orderLogic.getOrders();
            var destinations = mapper.Map<IEnumerable<OrderB>, IEnumerable<OrderDTOres>>(orders);
            return destinations;
        }



        public async Task<OrderB> updateOrderB(OrderDTO orderDTO)
        {
            OrderB newOrderB = mapper.Map<OrderB>(orderDTO);
            return await _orderLogic.UpdateOrder(newOrderB);
        }
    }
}
