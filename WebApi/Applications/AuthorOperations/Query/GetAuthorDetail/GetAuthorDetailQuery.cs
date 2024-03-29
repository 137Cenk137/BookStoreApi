using AutoMapper;
using WebApi.DBoperitions;
namespace WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }
    public GetAuthorDetailQuery(BookStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }
    public GetAuthorDetailViewModel Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.AuthorId == Id);
        if (author is null){throw new InvalidOperationException("yazar bulunamadı");}

        var result = _mapper.Map<GetAuthorDetailViewModel>(author);

        return result;


    }

}
public class GetAuthorDetailViewModel
{
    public int AuthorId { get; set; }
    public string Name { get; set;}
    public string SurName { get; set; }
    public DateTime Birthdate { get; set; }

}