

using System.Xml.Schema;
using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommand
{
    private readonly BookStoreDBContext _dbContext;
    public int Id { get; set; }
    public UpdateGenreCommandModel Model { get; set; }

    public UpdateGenreCommand(BookStoreDBContext dbContext)
    {
            _dbContext = dbContext;     
     
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);
        if (genre is null){throw new InvalidOperationException("Güncellenecek kitap türü bulunamadı");}
        if(_dbContext.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != Id)){
            throw new InvalidOperationException("Aynı isimli kitap türü mevcut ");
        }

       
        genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
         genre.IsActive = Model.IsActive;

        _dbContext.SaveChanges();

    }



}

public class UpdateGenreCommandModel
{
     public string Name { get; set; }

    public bool IsActive { get; set; }
}