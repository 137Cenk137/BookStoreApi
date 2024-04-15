using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.Crea;

public class CreateGenreValidatorTest : IClassFixture<CommanTestFixture>
{
    [Theory]
    [InlineData("")]
    [InlineData("2")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
    {
        var command = new CreateGenreCommand(null,null);
        CreateGenreModel model =new(){Name = name};

        command.Model = model;
        CreateGenreCommandValidator validations = new();
        var validate = validations.Validate(command);

        validate.Errors.Count.Should().BeGreaterThan(0);
    }
}