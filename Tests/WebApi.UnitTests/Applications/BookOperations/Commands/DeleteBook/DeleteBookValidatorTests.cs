using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.DeleteBook;
using WebApi.DBoperitions;
using Xunit;

namespace Tests.Applications.BookOperations.Commands.CreateBook;

public class DeleteBookValidatorTests : IClassFixture<CommanTestFixture>
{
    [Theory]
    [InlineData(-1)]
    
   public void WhenValitadortool_Valid_ShouldBeReturnErrors(int id)
   {
        DeleteBookCommand command = new(null){Id = id};
        DeleteBookCommandValidator validations = new();
        var result = validations.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);

   }
    
}
