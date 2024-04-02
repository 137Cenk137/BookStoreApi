using System.Security.AccessControl;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.BookOperations.CreateBook;
using WebApi.DBoperitions;

namespace Tests.Applications.BookOperations.Commands.CreateBook;
 
 public class CreateBookCommandTests: IClassFixture<CommanTestFixture>
 {
    private readonly BookStoreDBContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTests(CommanTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    } 

    [Fact]
    public void WhenAlreadyExistBookTitle_InvalidOperationsExceptions_shouldBeReturn()
    {
        // arrange(hazırlık)
        var book = new Book(){Title = "Test_WhenAlreadyExistBookTitle_InvalidOperationsExceptions_shouldBeReturn",PageCount = 123,GenreId = 2,PublishDate = new DateTime(2002,12,02)};
        _context.Books.Add(book);
        _context.SaveChanges();
        CreateBookCommand command= new CreateBookCommand(_context,_mapper);
        command.Model = new CreateBookModel(){Title = book.Title};


        //act(çalistiema) &assert(Dogrulamama)
        FluentActions.Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Zaten var");

    }
    [Fact]  
    public void WhenValiDInputAreGiven_Book_ShouldBeCreated()
    {
        CreateBookCommand command = new CreateBookCommand(_context,_mapper);
        var model = new CreateBookModel(){Title = "Hobbit",PageCount = 22,GenreId = 2,PublishDate = DateTime.Now.Date.AddYears(-10)};
        command.Model = model;
        FluentActions.Invoking(() => command.Handle()).Invoke();

        var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
        book.Should().NotBeNull();
        
        book.PageCount.Should().Be(model.PageCount);
        book.GenreId.Should().Be(model.GenreId);
        book.PublishDate.Should().Be(model.PublishDate);

    }
 }