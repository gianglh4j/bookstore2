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

    
}
