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

    public class BookDTORes
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<BookTypeDTOres> BookTypes { get; set; }
       
    }


    public class BookTypeDTOres
    {
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }
    }

    //public class BookTypeDTOres2
    //{
    //    public int Amount { get; set; }
    //    public int BookId { get; set; }
    //    public int OrderId { get; set; }

    //    public virtual Book Book { get; set; }
    //}












}
