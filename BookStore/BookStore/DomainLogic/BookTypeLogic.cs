using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DTO;
using BookStore.Models;
using BookStore.Repository;

namespace BookStore.DomainLogic
{
  
    public interface IBookTypeLogic
    {
        Task<BookType> AddBookType(BookType bookType);
        Task<BookType> UpdateBookType(BookType bookType);
        Task<BookType> GetBookType(int orderId);

        Task<IEnumerable<BookType>> getBookTypes();


    }
    public class BookTypeLogic : IBookTypeLogic
    {
        private readonly IBookTypeRepository _bookTypeRepository;
   

        public BookTypeLogic(IBookTypeRepository _bookTypeRepository)
        {
            this._bookTypeRepository = _bookTypeRepository;

        }

        public async Task<BookType> AddBookType(BookType bookType)
        {
            
            var result = await _bookTypeRepository.AddBookType(bookType);
            return result;
        }

        public async Task<BookType> GetBookType(int bookTypeId)
        {
            var result = await _bookTypeRepository.GetBookType(bookTypeId);
            return result;
        }

        public async Task<IEnumerable<BookType>> getBookTypes()
        {
            var result = await _bookTypeRepository.GetBookTypes();
            return result;
        }

        public async Task<BookType> UpdateBookType(BookType bookType)
        {
          
            var result = await _bookTypeRepository.UpdateBookType(bookType);

            return result;
          

        }

    }
}

