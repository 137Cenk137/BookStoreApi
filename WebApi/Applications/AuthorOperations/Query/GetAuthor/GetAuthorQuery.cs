using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        var  authors = _dbContext.Authors.Include(p => p.Books).OrderBy(x => x.AuthorId).ToList<Author>();
        List<GetAuthorViewModels> result =  _mapper.Map<List<GetAuthorViewModels>>(authors);
        return result;
    }
}

public class GetAuthorViewModels
{
    public List<Book> Books { get; set; }
    public string Name { get; set;}
    public string SurName { get; set; }
}