using System.Security.AccessControl;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.BookOperations.CreateBook;
using WebApi.DBoperitions;

namespace Tests.Applications.BookOperations.Commands.CreateBook;
 
 public class CreateBookCommandValidatorTests: IClassFixture<CommanTestFixture>
 {
   

    [Theory]
    [InlineData("Lord of The Rings",0,0)]
    [InlineData("Lord of The Rings",1,0)]
    [InlineData("Lord of The Rings",0,1)]
    [InlineData("",0,0)]
    [InlineData("",1,0)]
    [InlineData("",0,1)]
    [InlineData("",1,1)]  

    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount,int genreId )
    {
        //arrange
        CreateBookCommand command= new CreateBookCommand(null,null);
        command.Model = new CreateBookModel(){
            Title = title ,PageCount = pageCount,GenreId = genreId,PublishDate = DateTime.Now.Date.AddYears(-1)
        };
        //act
        CreateBookCommandValidator validations = new CreateBookCommandValidator();
        var result = validations.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenDatetimeEqualIsGiven_Validator_shouldBeReturnError()
    {
        CreateBookCommand command= new CreateBookCommand(null,null);
        command.Model = new CreateBookModel(){
            Title = "Lord of The Rings", PageCount = 1233,GenreId = 1,PublishDate = DateTime.Now.Date
        };
        //act
        CreateBookCommandValidator validations = new CreateBookCommandValidator();
        var result = validations.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputAreGiven_Validator_shouldNotBeReturnError()
    {
        CreateBookCommand command= new CreateBookCommand(null,null);
        command.Model = new CreateBookModel(){
            Title = "Lord of The Rings", PageCount = 1233,GenreId = 1,PublishDate = DateTime.Now.Date.AddYears(-1)
        };
        //act
        CreateBookCommandValidator validations = new CreateBookCommandValidator();
        var result = validations.Validate(command);
        //assert
        result.Errors.Count.Should().Be(0);
    } 

 }