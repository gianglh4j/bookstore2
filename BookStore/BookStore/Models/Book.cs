using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            BookBookType = new HashSet<BookBookType>();
            OrderBDetail = new HashSet<OrderBDetail>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<BookBookType> BookBookType { get; set; }
        public virtual ICollection<OrderBDetail> OrderBDetail { get; set; }
    }
}
