using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.Applications.AuthorOperations.Command.DeleteAuthor;
using Xunit;
namespace Tests.Applications.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorValidatorTest 
{
    [Theory]
    
    [InlineData(0)]

    public void WhenInvalidAreGiven_Validator_ShouldBeReturnsErrors(int shamId)
    {
        DeleteAuthorCommand command = new(null){AuthorId = shamId};

        DeleteAuthorValidator validator = new DeleteAuthorValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    
}