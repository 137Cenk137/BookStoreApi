using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands;

public class DeleteGenreValidatorTest : IClassFixture<CommanTestFixture>
{

    private readonly BookStoreDBContext _context;
    public DeleteGenreValidatorTest(CommanTestFixture testFixture)
    {
        _context = testFixture.Context;    
    }
    [Theory]
   [InlineData(2345)]
   [InlineData(0)]
   public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnError(int shamId)
   {
        DeleteGenreCommand command = new (_context){GenreId = shamId};

        var validations = new DeleteGenreCommandValidator();
        var result = validations.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);

   }
}