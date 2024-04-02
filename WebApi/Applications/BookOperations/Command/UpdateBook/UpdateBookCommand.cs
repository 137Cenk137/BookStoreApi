
using WebApi.DBoperitions;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookCommand
{
    public int Id { get; set; }
    public UpdateBookModel  Model { get; set; }

     
    private readonly IBookStoreDBContext _dbContext;
    public UpdateBookCommand(IBookStoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
         var book = _dbContext.Books.SingleOrDefault(p =>p.Id == Id);

        if (book is  null){throw new InvalidOperationException("Güncllenecek kitap bulunamadı");}

        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.Title = Model.Title != default ? Model .Title : book.Title;

        _dbContext.SaveChanges(); 
        
    }
}

public class UpdateBookModel
{
    public string Title { get; set; }
    public int GenreId { get; set; }
}