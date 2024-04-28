

using FluentAssertions;
using WebApi.Applications.AuthorOperations.Command.UpdateAuthor;
using Xunit;

namespace Tests.Applications.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorValidatorTest
{
    [Theory]
    [InlineData(0,"sdfgd","sdfgf")]
    [InlineData(0,"","")]
    [InlineData(0,"s","")]
    [InlineData(0,"sd","")]

    [InlineData(0,"s","s")]
    [InlineData(0,"s","sj")]

    [InlineData(0,"sdfgd","sdfgf")]
    public void WhenInvalidAreGiven_Validator_ShouldBeReturnErrors(int shamId,string shamName,string shamSurnae)
    {
        UpdateAuthorModel model = new(){
            SurName = shamSurnae,
            Name = shamName,

        };

        UpdateAuthorCommand command = new(null,null){AuthorId = shamId,Model = model};
        UpdateAuthorValidator validations = new();
        var result = validations.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);

    }
}