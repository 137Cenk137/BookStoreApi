using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel,Book> ();// CreateBookModel den book objesine dönüstürülür
        CreateMap<Book,GetBookDetailQueryResponseViewModel>().ForMember(dest => dest.Genre,opt=> opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        //        Source     Target
    }
}