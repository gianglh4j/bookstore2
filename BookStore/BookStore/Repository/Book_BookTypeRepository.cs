using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBook_BookTypeRepository
    {

        Task<BookBookType> addBook_BookType(BookBookType book_BookType);
        Task deleteBook_BookTypes(int bookId);

    }
    public class Book_BookTypeRepository : IBook_BookTypeRepository
    {
        private readonly BookStoredbContext _bookStoredbContext;
        public Book_BookTypeRepository(BookStoredbContext bookStoredbContext)
        {
            this._bookStoredbContext = bookStoredbContext;
        }

        public async Task<BookBookType> addBook_BookType(BookBookType book_BookType)
        {
           // _bookStoredbContext.Entry(book_BookType).State = EntityState.Detached;
            var result = await _bookStoredbContext.BookBookType.AddAsync(book_BookType);
            await _bookStoredbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task deleteBook_BookTypes(int bookId)
        {

            //remove book_bookTypes 
            var book_bookTypeToRemoves = await _bookStoredbContext.BookBookType.Where(e => e.BookId == bookId).ToListAsync();
            _bookStoredbContext.BookBookType.RemoveRange(book_bookTypeToRemoves);
            await _bookStoredbContext.SaveChangesAsync();

        }

       
    }
}
