
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Applications.UserOperations.Commands.RefreshToken;
using WebApi.DBoperitions;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class UserControllers : ControllerBase
{
    private readonly IBookStoreDBContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;//config bilgilerine ulasmamızı saglar

    public UserControllers(IBookStoreDBContext context,IMapper mapper,IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command  =  new(_context,_mapper);
        command.Model = newUser;
        command.Handle();

        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody]CreateTokenModel login)
    {
        CreateTokenCommand command = new(_context,_mapper,_configuration);
        command.Model = login;

        var token = command.Handle();
        return token;
    }
    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new(_context,_mapper,_configuration);
        command.RefreshToken = token;
        
        var resultToken = command.Handle();
        return resultToken;
    }
}