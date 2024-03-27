
using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommand
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public CreateGenreModel Model { get; set; }

    public CreateGenreCommand(BookStoreDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;     
         _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault( p => p.Name == Model.Name );
        if ( genre is not null ){throw new InvalidOperationException("Kitap Türü Mevcut"); }
        genre = new Genre();

        genre.Name = Model.Name;
        _dbContext.Genres.Add( genre );
        _dbContext.SaveChanges();
    }


}

public class CreateGenreModel
{
    public string Name { get; set;}
}