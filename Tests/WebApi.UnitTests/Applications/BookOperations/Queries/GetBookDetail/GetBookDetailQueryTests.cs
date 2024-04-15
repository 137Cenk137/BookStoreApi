
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.GetBookDetail;
using WebApi.DBoperitions;
using Xunit;


namespace Tests.Applications.BookOperations.Queries.GetBookDetail;

public class  GetBookDetailQueryTests : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetBookDetailQueryTests(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenIdNotExistInDB_InvalidOperationException_ShouldBeReturn()
    {
        int id = 12234;
        GetBookDetailQuery query = new(_dbContext,_mapper){BookId = id};

        FluentActions.Invoking(()=> query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("KitapBulunamadı");


    }
}