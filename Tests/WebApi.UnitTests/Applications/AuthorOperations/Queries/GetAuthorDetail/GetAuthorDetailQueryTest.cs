

using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;
using WebApi.DBoperitions;
using Xunit;

namespace Tests.Applications.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQueryTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetAuthorDetailQueryTest(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenIdNotExist_InvalidOperationException_ShouldBeReturn()
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_dbContext,_mapper){Id = 0};

        FluentActions.Invoking(()=>query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("yazar bulunamadı");
        

    }
}