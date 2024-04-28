
using FluentAssertions;
using WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;
using Xunit;

public class GetAuthorDetailValidatorTest
{
    [Theory]
    [InlineData(0)]
    public void WhenInvalidAreGiven_Validator_ShouldBeReturnErrors(int shamId)
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null){Id = shamId};
        GetAuthorDetaikValidator validations = new();
        var result = validations.Validate(query);

        result.Errors.Count.Should().BeGreaterThan(0);

    }

}