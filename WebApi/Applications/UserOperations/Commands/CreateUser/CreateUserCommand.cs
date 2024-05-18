using AutoMapper;
using WebApi.DBoperitions;
using WebApi.Entities;

namespace  WebApi.Applications.UserOperations.Commands.CreateUser;

public class CreateUserCommand 
{
    private readonly IBookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public CreateUserModel Model { get; set; }

    public CreateUserCommand(IBookStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }
    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
        if(user is not null)
        {throw new InvalidOperationException("User has already  exist");}

        var user2 = _mapper.Map<User>(Model);
        var user1 = new User { Name = "Mehmet",SurName= "Fikir",Email = "test@gmail.com",Password = "3dtsfr5frg",RefreshToken = "ertghgrer"};
        _dbContext.Users.Add(user2);
        
        _dbContext.SaveChanges();

    }
}

public class CreateUserModel
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}