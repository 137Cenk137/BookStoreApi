using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.GetBookDetail;
using WebApi.DBoperitions;

using Xunit;

namespace Tests.Applications.BookOperations.Queries.GetBookDetail;
public class GetBookDetailValidatorTest : IClassFixture<CommanTestFixture>
{
    
    private readonly BookStoreDBContext _dbContext;
    public GetBookDetailValidatorTest(CommanTestFixture testFixture)
    {
        _dbContext= testFixture.Context;
    }
    [Theory]
    [InlineData(-1)]
    //[InlineData(1)]
    [InlineData(12334)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
    {
        
        GetBookDetailQuery query = new(null,null){BookId = id};
        GetBookDetailQueryValidator validations = new(_dbContext);
        var result = validations.Validate(query);
        result.Errors.Count.Should().BeGreaterThan(0);
;
    }
}