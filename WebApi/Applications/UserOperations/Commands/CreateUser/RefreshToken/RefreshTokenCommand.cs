using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBoperitions;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Applications.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{
    private readonly IBookStoreDBContext  _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public string RefreshToken { get; set; }

    public RefreshTokenCommand(IBookStoreDBContext bookStoreDBContext, IMapper mapper, IConfiguration configuration)        
    {
            _dbContext = bookStoreDBContext;
            _mapper = mapper;   
            _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
        if(user is not null)
        {
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }
        else
        {
            throw new InvalidOperationException("can not find valid user");
        }

    }
}