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
        OrderB setOrderPost(OrderDTO orderDTO);

        Task<OrderB> addOrder(OrderDTO orderDTO);

        Task<OrderDTO> updateOrderB(OrderDTO orderDTO);

        Task<IEnumerable<OrderB>> getOrders();

        Task<OrderDTO> getOder(int bookId);

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

        public Task<OrderDTO> getOder(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderB>> getOrders()
        {
            return await _orderLogic.getOrders();
        }

        public OrderB setOrderPost(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> updateOrderB(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
