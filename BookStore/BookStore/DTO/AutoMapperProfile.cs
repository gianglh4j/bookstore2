using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
namespace BookStore.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<OrderDTO, OrderB>();
            CreateMap<Book, BookDTO > ();
            CreateMap<OrderB, OrderDTO > ();
            //  CreateMap<Book, BookDTORes>().ForMember(destination => destination.BookTypes, opt => opt.MapFrom(src => src.BookBookType));
            // CreateMap<BookBookType, BookTypeDTORes>().ForMember(destination => destination.BookTypeId, opt => opt.MapFrom(src => src.BookType.BookTypeId)).ForMember(destination => destination.BookTypeName, opt => opt.MapFrom(src => src.BookType.BookTypeName));


            // CreateMap<BookType, BookTypeDTORes3>().ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.BookBookType));
            // CreateMap<BookBookType, BookDTORes>().ForMember(destination => destination.BookId, opt => opt.MapFrom(src => src.Book.BookId)).ForMember(destination => destination.BookImage, opt => opt.MapFrom(src => src.Book.BookImage)).ForMember(destination => destination.BookName, opt => opt.MapFrom(src => src.Book.BookName)).ForMember(destination => destination.BookPrice, opt => opt.MapFrom(src => src.Book.BookPrice));



        }
    }
}
