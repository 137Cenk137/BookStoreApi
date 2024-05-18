using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.BookOperations.GetBook;
using WebApi.DBoperitions;

namespace WebApi.Applications.AuthorOperations.Query.GetAuthor;

public class GetAuthorQuery
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetAuthorQuery(BookStoreDBContext dbContext, IMapper mapper)     
    {
            _dbContext = dbContext; 
            
            _mapper = mapper;
    }

    public List<GetAuthorViewModels> Handle()
    {
        List<GetAuthorViewModels> authors = _dbContext.Authors.Include(p => p.Books)
                                                               .ThenInclude(x => x.Genre)
                                                               .OrderBy(x => x.AuthorId)
                                                               .SelectMany(x =>x.Books,(x,u)=>new GetAuthorViewModels
        {
            Books = _mapper.Map<ICollection<BookViewModelForAuthor>>(x.Books),
            Name = x.Name,
            SurName  = x.SurName,
        } ).ToList();
        List<GetAuthorViewModels> result =  _mapper.Map<List<GetAuthorViewModels>>(authors);
        return result;
    }
}

public class GetAuthorViewModels
{
    public ICollection<BookViewModelForAuthor> Books { get; set; }
    public string Name { get; set;}
    public string SurName { get; set; }
}

public class BookViewModelForAuthor
{
    public  string Title { get; set; }
    public string Genre { get; set; }

    public int PageCount { get; set; }
    public string PublishDate { get; set; }
}