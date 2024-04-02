using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperitions;

namespace Tests.Applications.BookOperations.Commands.UpdateBook;

public class UpdateBookValidatorTests : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    

    public UpdateBookValidatorTests(CommanTestFixture fixture)
    {
        _dbContext = fixture.Context;
        
    }
    [Theory]
    [InlineData("", 1)]
    [InlineData("a", 1)]
    [InlineData("as", 1)]
    [InlineData("add", 1)]
    
    [InlineData("", 4)]
    
    public void WhenInputModelNotTrueRules_Validate_ShouldBeReturnErrors(string title,int genreId)
    {
        var model = new UpdateBookModel(){Title = title,GenreId = genreId};
        UpdateBookCommand command = new(null){Id = 2};
        command.Model = model;
        UpdateBookCommandValidator validations = new();

        var result = validations.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
        
    }
}