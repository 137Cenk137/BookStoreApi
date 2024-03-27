using WebApi.DBoperitions;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommand
{
    private readonly BookStoreDBContext _dbContext;
    public int GenreId { get; set; }
    public int _lenghtOfContext { get; private set; }
    public DeleteGenreCommand(BookStoreDBContext dbContext)
    {
        _dbContext = dbContext;
        _lenghtOfContext = _dbContext.Genres.Count();
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
        if(genre is  null){throw new InvalidOperationException("Silinecek kiatp bulunamadı");}
        _dbContext.Genres.Remove(genre);
        _dbContext.SaveChanges();

    }

}