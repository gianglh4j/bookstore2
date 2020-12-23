using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int? TotalPrice { get; set; }

        public virtual ICollection<OrderBDetail> OrderBDetail { get; set; }

    }

    public class OrderDTOres
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int? TotalPrice { get; set; }

        public virtual ICollection<BookResOrder> Books { get; set; }

        public UserOrderDTOres userOrderDTOres { get; set; }


    }
    public class UserOrderDTOres
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class BookResOrder
    {

        public int Amount { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }

    }


}
