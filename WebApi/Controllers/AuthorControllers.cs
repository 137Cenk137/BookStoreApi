using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.Applications.AuthorOperations.Command.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Command.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Query.GetAuthor;
using WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperitions;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class AuthorController:ControllerBase
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public AuthorController(BookStoreDBContext dbContext, IMapper mapper)   
    {
            _dbContext = dbContext;
            _mapper = mapper;

    }

    [HttpGet]
    public IActionResult GetAuthor()
    {
        GetAuthorQuery query = new GetAuthorQuery(_dbContext,_mapper);
        var result = query.Handle();

        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetDetailAuthor(int id)
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_dbContext,_mapper){Id = id};
        GetAuthorDetaikValidator validations = new();

        validations.ValidateAndThrow(query);

        var result = query.Handle();

        return Ok(result);
    }
    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel author)
    {
        CreateAuthorCommand command = new(_dbContext,_mapper){Model = author};
        CreateAuthorValidator validations =new();
        validations.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand  command = new DeleteAuthorCommand(_dbContext){AuthorId = id};
        DeleteAuthorValidator validations = new();
        validations.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel author)
    {
        UpdateAuthorCommand command =new(_dbContext,_mapper){Model = author,AuthorId = id};
        UpdateAuthorValidator validations =new();
        validations.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

}