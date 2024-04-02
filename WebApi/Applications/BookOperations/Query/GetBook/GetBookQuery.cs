using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBoperitions;
namespace WebApi.BookOperations.GetBook;

public class GetBookQuery
{
    private readonly IBookStoreDBContext _bookStoreDBContext;
    private readonly IMapper _mapper;

    public GetBookQuery(IBookStoreDBContext bookStoreDBContext, IMapper mapper)
    {
        _bookStoreDBContext = bookStoreDBContext;
        _mapper = mapper;
        
    }

    public List<BooksViewModel> Handle()
    {
        var bookList = _bookStoreDBContext.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy(x => x.Id).ToList<Book>();
        List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList); //new();
        //foreach (var book in bookList)
        //{
        //    vm.Add(new BooksViewModel(){
        //        Title = book.Title,
         //       PageCount = book.PageCount,
        //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"), 
         //       Genre = ((GenreEnum)book.GenreId).ToString()
         //       
         //   });
        //}//
        return vm;
    }
}

public  class BooksViewModel
{
    public  string Title { get; set; }
    public string Genre { get; set; }

    public int PageCount { get; set; }
    public string  Author  { get; set; }
    public string PublishDate { get; set; }
} 