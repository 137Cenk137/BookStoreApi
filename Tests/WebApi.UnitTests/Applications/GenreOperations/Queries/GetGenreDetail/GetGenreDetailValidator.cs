using FluentAssertions;
using WebApi.Applications.GenreOperations.Query.GetGenres;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Queries.GetGenreDetail;

public class GetGenreDetailValidator 
{
    [Theory]
    [InlineData(0)]

    public void WhenInvalidAreGiven_Validator_ShouldBeReturn(int shamId)
    {
        GetGenresDetailQuery query =new(null,null){GenreId = shamId};

        GetGenresDetailQueryValidator validations  = new();
        var result = validations.Validate(query);
        result.Errors.Count.Should().BeGreaterThan(0);

    }
}