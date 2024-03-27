using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.GetBookDetail;


public class GetBookDetailQuery
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId { get; set; }
    public GetBookDetailQuery( BookStoreDBContext dbContext,IMapper mapper )
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public GetBookDetailQueryResponseViewModel Handle()
    {
        var bookList =  _dbContext.Books.Include(x => x.Genre).SingleOrDefault(p => p.Id == BookId);

        if (bookList == null){throw new InvalidOperationException("KitapBulunamadı");}
        
         GetBookDetailQueryResponseViewModel vm = _mapper.Map<GetBookDetailQueryResponseViewModel>(bookList); //new();
        //vm.Title = bookList.Title;
        //vm.Genre = ((GenreEnum)bookList.GenreId).ToString();
        //vm.PageCount = bookList.PageCount;
        //vm.PublishDate = bookList.PublishDate.ToString("dd/MM/yyyy");
       return vm ; 

    }

}


public class GetBookDetailQueryResponseViewModel
{
     public string Genre { get; set; }
     public string Title { get; set; }
     public int PageCount { get; set; }
     public string PublishDate { get; set; }
}