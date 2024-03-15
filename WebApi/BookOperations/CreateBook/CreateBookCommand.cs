using WebApi.DBoperitions;

namespace WebApi.BookOperations.CreateBook;

public class CreateBookCommand
{
    private readonly BookStoreDBContext _dbContext;

    public CreateBookModel Model { get; set; }
    public CreateBookCommand(BookStoreDBContext bookStoreDBContext)
    {
        _dbContext = bookStoreDBContext;
    }
    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(p => p.Title == Model.Title);
        if(book is not null){throw new InvalidOperationException("Kitap Zaten var");}

        book = new Book();
        book.Title = Model.Title;
        book.PublishDate = Model.PublishDate;
        book.PageCount = Model.PageCount;
        book.GenreId = Model.GenreId;

        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();

    }
    
}

public class CreateBookModel
{
    public string Title { get; set;}
    public int GenreId { get; set; }

    public int PageCount { get; set; }

    public DateTime PublishDate { get; set; }

    
}