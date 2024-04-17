using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommandTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    public UpdateGenreCommandTest(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
    }
    [Fact]
    public void WhenIdDoesntExsit_InvalidOperationException_ShouldBeReturn()
    {


        UpdateGenreCommand command =new(_dbContext){Id = 1233};
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap türü bulunamadı");
        

    }
    [Fact]
    
    public void WhenNewGenreNameAlreadyExist_InvalidOperationException_ShouldBeReturn()
    {
        Genre genre= new Genre(){Name = "example"};
        _dbContext.Genres.Add(genre);
        _dbContext.SaveChanges();
        UpdateGenreCommandModel model = new(){Name = genre.Name};
        UpdateGenreCommand command =new(_dbContext){Id = 2,Model = model};
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli kitap türü mevcut ");
        

    }
    

}