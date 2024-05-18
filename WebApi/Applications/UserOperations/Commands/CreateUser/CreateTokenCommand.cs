using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DBoperitions;
using WebApi.Entities;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace  WebApi.Applications.UserOperations.Commands.CreateUser;

public class CreateTokenCommand 
{
    private readonly IBookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public CreateTokenModel Model { get; set; }


    public CreateTokenCommand(IBookStoreDBContext dbContext, IMapper mapper, IConfiguration configuration)
    {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _dbContext.Users.FirstOrDefault(p => p.Email == Model.Email && p.Password == Model.Password);
        if (user is not  null)
        {
            //token yarat
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }
        else 
        {
            throw new InvalidOperationException("Kullanıcı adi-Sifre hatalı");
        }

    }
}

public class CreateTokenModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}