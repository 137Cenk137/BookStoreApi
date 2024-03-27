using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.GenreOperations.Query.GetGenres;
public class GetGenresQuery
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetGenresQuery( BookStoreDBContext dbContext,IMapper mapper)    
    {   
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<GetGenresQueryViewModels> Handle()
    {
        var genres = _dbContext.Genres.Where(p => p.IsActive == true).OrderBy(p => p.Id);

        List<GetGenresQueryViewModels> result = _mapper.Map<List<GetGenresQueryViewModels>>(genres);

        return result;
    }

}

public class GetGenresQueryViewModels
{
     public int Id { get; set;}
     public string  Name { get; set; }

}