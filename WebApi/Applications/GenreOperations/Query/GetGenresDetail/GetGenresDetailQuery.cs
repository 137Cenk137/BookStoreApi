using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.GenreOperations.Query.GetGenres;


public class GetGenresDetailQuery
{
    public int GenreId { get; set; }
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetGenresDetailQuery(BookStoreDBContext dbContext, IMapper mapper)
    {
         _dbContext = dbContext; 
         _mapper = mapper;
    }

    public GetGenresDetailQueryViewModels Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x=> x.IsActive == true && x.Id == GenreId);
        if (genre is null){throw new InvalidOperationException("Kitap türü Bulunamadı");};


        GetGenresDetailQueryViewModels result = _mapper.Map<GetGenresDetailQueryViewModels>(genre);

        return result;
    }
}

public class GetGenresDetailQueryViewModels
{
     public int Id { get; set;}
     public string  Name { get; set; }

}