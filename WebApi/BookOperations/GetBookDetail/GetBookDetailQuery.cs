using WebApi.Common;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.GetBookDetail;


public class GetBookDetailQuery
{
    private readonly BookStoreDBContext _dbContext;

    public int BookId { get; set; }
    public GetBookDetailQuery( BookStoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public GetBookDetailQueryResponseViewModel Handle()
    {
        var bookList =  _dbContext .Books.SingleOrDefault(p => p.Id == BookId);

        if (bookList == null){throw new InvalidOperationException("KitapBulunamadı");}
        
         GetBookDetailQueryResponseViewModel vm =new();
        vm.Title = bookList.Title;
        vm.Genre = ((GenreEnum)bookList.GenreId).ToString();
        vm.PageCount = bookList.PageCount;
        vm.PublishDate = bookList.PublishDate.ToString("dd/MM/yyyy");
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