using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.CreateBook;

public class CreateBookCommand
{
    private readonly IBookStoreDBContext _dbContext;
    private readonly IMapper _mapper;

    public CreateBookModel Model { get; set; }

    public CreateBookCommand(IBookStoreDBContext bookStoreDBContext,IMapper mapper)
    {
        _dbContext = bookStoreDBContext;
        _mapper = mapper;
    }
    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(p => p.Title == Model.Title);
        if(book is not null){throw new InvalidOperationException("Kitap Zaten var");}

        book = _mapper.Map<Book>(Model);// book a dönüstürür

        //book.Title = Model.Title;
        //book.PublishDate = Model.PublishDate;
        //book.PageCount = Model.PageCount;
        //book.GenreId = Model.GenreId;

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