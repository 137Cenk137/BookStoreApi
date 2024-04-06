using FluentAssertions;
using TestsSetup;
using WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;
using WebApi.Applications.GenreOperations.Query.GetGenres;
using WebApi.DBoperitions;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Queries.GetGenreDetail;

public class GetGenresDetailQueryTests : IClassFixture<CommanTestFixture>
{
    private  readonly BookStoreDBContext _dbContext;
   public GetGenresDetailQueryTests(CommanTestFixture testFixture) => _dbContext = testFixture.Context;
   
   [Fact]
   public void WhenIdIsNotExist_InvalidOperationException_ShouldBeReturn()
   {
    int id = 123;
     GetGenresDetailQuery query = new(_dbContext,null){GenreId = id};
     FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü Bulunamadı");

   }
}