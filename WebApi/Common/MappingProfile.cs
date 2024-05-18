using AutoMapper;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.Applications.AuthorOperations.Command.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Query.GetAuthor;
using WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;
using WebApi.Applications.GenreOperations.Query.GetGenres;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.Entities;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel,Book> ();// CreateBookModel den book objesine dönüstürülür
        CreateMap<Book,GetBookDetailQueryResponseViewModel>().
        ForMember(dest => dest.Author,opt => opt.MapFrom(src => src.Author.Name)).
        ForMember(dest => dest.Genre,opt=> opt.MapFrom(src => src.Genre.Name));

        CreateMap<Book,BooksViewModel>().
        ForMember(dest => dest.Author,opt => opt.MapFrom(src => src.Author.Name)).
        ForMember(dest => dest.Genre,opt => opt.MapFrom(src => src.Genre.Name));

        CreateMap<Genre,GetGenresQueryViewModels>();
        CreateMap<Genre,GetGenresDetailQueryViewModels>();

        CreateMap<Author,GetAuthorViewModels>().ForMember(dest => dest.Books,opt => opt.MapFrom(src => src.Books));
        CreateMap<Author,GetAuthorDetailViewModel>();
        CreateMap<CreateAuthorModel,Author>();
        CreateMap<UpdateAuthorModel,Author>();
        //Update
        CreateMap<Book,BookViewModelForAuthor>().ForMember(dest => dest.Genre,opt =>opt.MapFrom(src => src.Genre.Name));
        //        Source     Target
        CreateMap<CreateUserModel,User>();

    }
}