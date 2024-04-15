
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.Crea;
 
public class CreateGenreCommandTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;

    public CreateGenreCommandTest(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
        _mapper = testFixture.Mapper;

    }
    [Fact]
    public void WhenGenreAlreadyExist_InvalidOperationException_ShouldBeReturn()
    {
        var genre = new Genre(){Name = "Actions"};
        _dbContext.Genres.Add(genre);
        _dbContext.SaveChanges();
        CreateGenreModel model = new CreateGenreModel(){Name = "Actions"};
        CreateGenreCommand command = new(_dbContext, _mapper){Model= model};

        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Mevcut");


    }
}