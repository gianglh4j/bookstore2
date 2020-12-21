using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DTO;
using BookStore.Models;

namespace BookStore.DTO
{
    public class BookDTO
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<BookBookType> BookBookType { get; set; }
        public virtual ICollection<OrderBDetail> OrderBDetail { get; set; }


    }





 






}
