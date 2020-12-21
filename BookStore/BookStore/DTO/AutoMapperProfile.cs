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
            CreateMap<Book, BookDTORes>().ForMember(destination => destination.BookTypes, opt => opt.MapFrom(src => src.BookBookType));
            CreateMap<BookBookType, BookTypeDTOres>().ForMember(destination => destination.BookTypeId, opt => opt.MapFrom(src => src.BookType.BookTypeId)).ForMember(destination => destination.BookTypeName, opt => opt.MapFrom(src => src.BookType.BookTypeName));


            //CreateMap<BookType, BookTypeDTOres2>().ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.BookBookType));
            CreateMap<BookBookType, BookDTORes>().ForMember(destination => destination.BookId, opt => opt.MapFrom(src => src.Book.BookId)).ForMember(destination => destination.BookImage, opt => opt.MapFrom(src => src.Book.BookImage)).ForMember(destination => destination.BookName, opt => opt.MapFrom(src => src.Book.BookName)).ForMember(destination => destination.BookPrice, opt => opt.MapFrom(src => src.Book.BookPrice)).ForMember(destination => destination.IsDeleted, opt => opt.MapFrom(src => src.Book.IsDeleted));

            CreateMap<OrderB, OrderDTOres>().ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.OrderBDetail));
            CreateMap<OrderBDetail, BookResOrder>().ForMember(destination => destination.Amount, opt => opt.MapFrom(src => src.Amount)).ForMember(destination => destination.BookId, opt => opt.MapFrom(src => src.Book.BookId)).ForMember(destination => destination.BookName, opt => opt.MapFrom(src => src.Book.BookName));

            CreateMap<BookTypeDTO, BookType>();
            CreateMap<BookType, BookTypeDTO>();

        }
    }
}
