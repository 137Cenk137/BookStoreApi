using WebApi.DBoperitions;

namespace WebApi.Applications.AuthorOperations.Command.DeleteAuthor;

public class DeleteAuthorCommand
{
    private readonly BookStoreDBContext _dbContext;
    public int AuthorId { get; set; }
    public DeleteAuthorCommand(BookStoreDBContext dbContext)
    {
            _dbContext = dbContext;
    }
    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
        if (author is null){throw new InvalidOperationException("silinecek kitap bulunamadı");}
        _dbContext.Authors.Remove(author);
        _dbContext.SaveChanges();
    }
}