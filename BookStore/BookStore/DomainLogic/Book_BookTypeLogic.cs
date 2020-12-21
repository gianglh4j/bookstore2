using BookStore.DTO;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;

namespace BookStore.DomainLogic
{
    public interface IBook_BookTypeLogic
    {
        Task<BookBookType> addBook_BookType(BookBookType book_BookType);
        Task deleteBook_BookTypes(int bookId);


    }
    public class Book_BookTypeLogic : IBook_BookTypeLogic
    {
        private readonly IBook_BookTypeRepository _book_BookTypeRepository; 
        public Book_BookTypeLogic(IBook_BookTypeRepository book_BookTypeRepository)
        {
            this._book_BookTypeRepository = book_BookTypeRepository;

        }

        public async Task<BookBookType> addBook_BookType(BookBookType book_BookType)
        {
            return await _book_BookTypeRepository.addBook_BookType(book_BookType);
        }

        public async Task deleteBook_BookTypes(int bookId)
        {
             await _book_BookTypeRepository.deleteBook_BookTypes(bookId);
        }
    }
}
