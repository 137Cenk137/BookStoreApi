using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.CreateGenre;

public class DeleteGenreCommandtest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;

    public DeleteGenreCommandtest(CommanTestFixture testFixture)
    {
      _dbContext = testFixture.Context;  
    }
    [Fact]
    public void WhenGenreIdDontExist_InvalidOperationException_ShouldBeReturn()
    {
        //
        DeleteGenreCommand command = new (_dbContext){GenreId = 1234};
        
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kiatp bulunamadı");
    }

}