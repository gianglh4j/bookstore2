using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.DTO;
using AutoMapper;
using BookStore.DomainLogic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        private static readonly HttpClient client = new HttpClient();
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
            return await setUserToOrder(destinations);
           
        }
        public  async Task<OrderDTOres> setUserToOrder( OrderDTOres order)
        {
            var responseTask = await client.GetAsync($"https://jsonplaceholder.typicode.com/users/{order.UserId}");
            var userString = responseTask.Content.ReadAsStringAsync().Result;
            // JObject json = JObject.Parse(userString);
            var myJsonObject = JsonConvert.DeserializeObject<UserOrderDTOres>(userString);
            order.userOrderDTOres = myJsonObject;
            return order;
        }

        public async Task<IEnumerable<OrderDTOres>> getOrders()
        {


            var orders = await _orderLogic.getOrders();
            var destinations = mapper.Map<IEnumerable<OrderB>, IEnumerable<OrderDTOres>>(orders);


            // get user info in order
            foreach (OrderDTOres order in destinations)
            {

              await setUserToOrder(order);
            } 
            //var result = responseTask.
            return destinations;
        }



        public async Task<OrderB> updateOrderB(OrderDTO orderDTO)
        {
            OrderB newOrderB = mapper.Map<OrderB>(orderDTO);
            return await _orderLogic.UpdateOrder(newOrderB);
        }
    }
}
