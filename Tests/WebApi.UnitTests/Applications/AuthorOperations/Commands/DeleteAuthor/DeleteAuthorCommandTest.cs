using System.Runtime.CompilerServices;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Applications.AuthorOperations.Command.DeleteAuthor;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.Applications.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommandTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;


    public DeleteAuthorCommandTest(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
        
    }
    [Fact]
    public void WhenIdNotFind_InvalidOperationException_ShouldBeReturn()
    {
        DeleteAuthorCommand command =new DeleteAuthorCommand(_dbContext){AuthorId = 1234565423};
        
        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("silinecek kitap bulunamadı");
    }

    
} 