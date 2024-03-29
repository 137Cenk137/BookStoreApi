using AutoMapper;
using WebApi.DBoperitions;

namespace WebApi.Applications.AuthorOperations.Command.CreateAuthor;
public class CreateAuthorCommand
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public CreateAuthorModel Model { get; set; }

    public CreateAuthorCommand(BookStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext;     
            _mapper = mapper;   
    }

    public void Handle()
    {

        Author author = _dbContext.Authors.SingleOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());

        if (author is not null)
        {throw new InvalidOperationException("Bu yazar zaten var");}
        var result = _mapper.Map<Author>(Model);
        _dbContext.Authors.Add(result);
        _dbContext.SaveChanges();

    }
}

public class CreateAuthorModel
{
    public string Name { get; set;}

    public string SurName { get; set; }
    public DateTime Birthdate { get; set; }

}