

using System.Data.Common;
using FluentAssertions;
using TestsSetup;
using WebApi;
using WebApi.BookOperations.DeleteBook;
using WebApi.DBoperitions;

namespace Tests.Applications.BookOperations.Commands.CreateBook;

public class DeleteBookCommandTests : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;

    public DeleteBookCommandTests(CommanTestFixture testFixture) => _dbContext =testFixture.Context ;

    [Fact]
    public void WhenIdNotExistInDataBase_InvalidOperationException_ShouldBeReturn()
    {
        // Given
        var  book = new Book(){Id = 11233};
        // When
        DeleteBookCommand command = new DeleteBookCommand(_dbContext){Id = book.Id};
        FluentActions.Invoking(()=> command.Handle()).Should().
        Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitapbulunamadı");

        // Then
    }
    
}
