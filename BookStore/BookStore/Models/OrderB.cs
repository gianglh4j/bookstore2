using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class OrderB
    {
        public OrderB()
        {
            OrderBDetail = new HashSet<OrderBDetail>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int? TotalPrice { get; set; }

        public virtual ICollection<OrderBDetail> OrderBDetail { get; set; }
    }
}
