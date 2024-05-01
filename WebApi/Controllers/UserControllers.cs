
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBoperitions;

namespace WebApi.Controllers;

[ApiController]
[Route("[controllers]s")]
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
}