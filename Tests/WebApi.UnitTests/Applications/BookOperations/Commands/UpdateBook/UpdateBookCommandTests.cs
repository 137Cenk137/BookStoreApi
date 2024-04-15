
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperitions;
using Xunit;

namespace Tests.Applications.BookOperations.Commands.UpdateBook;

public class  UpdateBookCommandTests: IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _context ;
    private readonly IMapper _mapper ;
    public UpdateBookCommandTests(CommanTestFixture commanTestFixture)
    {
            _context = commanTestFixture.Context;
            _mapper = commanTestFixture.Mapper;

    }
    [Fact]
    public void WhenAlreadyNotExistId_InvalidOperationException_ShoudBeReturn()
    {
        // Given
        var book = new Book { Id =12};
        UpdateBookCommand command = new UpdateBookCommand(_context){Id = book.Id};
        
        
        FluentActions.Invoking(() =>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncllenecek kitap bulunamadı");
    }
    [Fact]
    public void WhenAlreadyExistId_Success_ShoudBeReturn()
    {
        // Given
        var book = new Book { Id =1};
        
        UpdateBookModel model = new UpdateBookModel()
        {
            GenreId = 1,
            Title = "dfdfvgbhnjgffg"
        };
        UpdateBookCommand command = new UpdateBookCommand(_context){Id = book.Id,Model = model};
        
        FluentActions.Invoking(() => command.Handle()).Invoke();
        command.Model.GenreId.Should().Be(model.GenreId);
        command.Model.Title.Should().Be(model.Title);
    }

}