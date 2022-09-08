using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace Library;

public class MappingProfile : Profile 
{
    public MappingProfile()
    {
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();

        CreateMap<BookDto, Book>();
        CreateMap<Book, BookDto>();

        CreateMap<BorrowmentDto, Borrowment>();
        CreateMap<Borrowment, BorrowmentDto>();

        CreateMap<PersonDto, Person>();
        CreateMap<Person, PersonDto>();
    }
}
