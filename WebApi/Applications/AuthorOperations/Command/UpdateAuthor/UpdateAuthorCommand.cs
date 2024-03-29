using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorCommand
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateAuthorModel Model { get; set; }
    public int AuthorId { get; set; }

    public UpdateAuthorCommand(BookStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext; 
            _mapper = mapper;
    }
    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
        if(author is null){throw new InvalidOperationException("Yazar bulunamadı"); }
        author.SurName = Model.SurName == default ? author.SurName : Model.SurName;
        author.Name = Model.Name == default ? author.Name : Model.Name;

        _dbContext.SaveChanges();
    }
}
public class UpdateAuthorModel
{
    public string Name { get; set;}

    public string SurName { get; set; }

}