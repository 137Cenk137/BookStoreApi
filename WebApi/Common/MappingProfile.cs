using AutoMapper;
using WebApi.Applications.GenreOperations.Query.GetGenres;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel,Book> ();// CreateBookModel den book objesine dönüstürülür
        CreateMap<Book,GetBookDetailQueryResponseViewModel>().ForMember(dest => dest.Genre,opt=> opt.MapFrom(src => src.Genre.Name));
        CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Genre,GetGenresQueryViewModels>();
        CreateMap<Genre,GetGenresDetailQueryViewModels>();
        //        Source     Target
    }
}