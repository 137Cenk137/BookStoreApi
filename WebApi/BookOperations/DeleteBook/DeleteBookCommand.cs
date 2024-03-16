using System.ComponentModel;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.DeleteBook;

public class DeleteBookCommand
{
    private readonly BookStoreDBContext _dbContext;
    public int Id { get; set; }
   

    public DeleteBookCommand(BookStoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
         var book = _dbContext.Books.SingleOrDefault(p => p.Id == Id  );
        if (book is null){throw new  InvalidOperationException("Silinecek kitapbulunamadı");}

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
    }

}
