

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.Applications.GenreOperations.Query.GetGenres;
using WebApi.DBoperitions;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]

public class GenreControllers : ControllerBase
{
    private readonly BookStoreDBContext _context;
    private readonly IMapper _mapper;

    public GenreControllers(BookStoreDBContext context, IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetGenre()
    {
        GetGenresQuery getGenresQuery= new GetGenresQuery(_context,_mapper);
        var result = getGenresQuery.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetDetail(int id)
    {
        var detailQuery = new GetGenresDetailQuery(_context,_mapper){GenreId = id};
        GetGenresDetailQueryValidator validations = new GetGenresDetailQueryValidator();
        validations.ValidateAndThrow(detailQuery); 

        var result = detailQuery.Handle();
        return Ok(result); 
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel genre)
    {
        CreateGenreCommand command  =  new(_context,_mapper){Model = genre};
        CreateGenreCommandValidator validations = new();
        validations.ValidateAndThrow(command);

        command.Handle();
        return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new(_context){GenreId = id};
        DeleteGenreCommandValidator validations = new();
        validations.ValidateAndThrow(command);

        command.Handle();
        return Ok();

    }
    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreCommandModel model )
    {
        UpdateGenreCommand command = new(_context){Id = id,Model = model};
        UpdateGenreValidator validations =new();
        validations.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
}