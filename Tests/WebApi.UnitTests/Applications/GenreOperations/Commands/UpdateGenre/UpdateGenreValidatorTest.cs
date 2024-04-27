using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreValidatorTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    public UpdateGenreValidatorTest(CommanTestFixture testFixture)  
    {
        _dbContext = testFixture.Context;
    }

    [Theory]
    [InlineData(0,"")]
    [InlineData(0," m")]
    [InlineData(0,"a")]
    [InlineData(0,"as")]
    [InlineData(0,"adv")]
    [InlineData(12,"l")]
    //[InlineData(12,"dfgbmfö")]
    
    public void WhenInvalidAreGiven_Validator_ShouldBeReturn(int shamId,string shamName)
    {
        UpdateGenreCommand command = new(null);
        UpdateGenreCommandModel model = new(){Name = shamName};
        command.Model = model;
        command.Id = shamId;
        UpdateGenreValidator validations = new();
        var result = validations.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
}
