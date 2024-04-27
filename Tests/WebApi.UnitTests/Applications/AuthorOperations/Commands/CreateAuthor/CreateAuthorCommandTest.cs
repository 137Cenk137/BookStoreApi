using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.DBoperitions;
using Xunit;
namespace Tests.Applications.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandTest : IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public CreateAuthorCommandTest(CommanTestFixture testFixture)
    {
        _dbContext  =   testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAuthorAlreadyExist_InvalidOperationException_ShoulBeReturn()
    {
        // rearrange
        Author author= new Author(){Name = "Akan"};
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();

        CreateAuthorCommand command = new CreateAuthorCommand(_dbContext,_mapper);
        CreateAuthorModel model = new(){Name = author.Name};
        command.Model = model;
        // assert act

        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu yazar zaten var");
        
    }

    [Fact]
    public void WhenValiDInputAreGiven_Author_ShouldBeCreated()
    {
        Author author= new Author(){Name = "Akan",SurName = "Katip",Birthdate =DateTime.Now.Date.AddYears(-10)};
        CreateAuthorCommand command =new(_dbContext,_mapper)
        {
            Model = new CreateAuthorModel(){Name = author.Name,SurName=author.SurName,Birthdate=author.Birthdate}
        };

        FluentActions.Invoking(() => command.Handle()).Invoke();

        var searchingAuthor = _dbContext.Authors.FirstOrDefault(a => a.Name == author.Name);
        searchingAuthor.Should().NotBeNull();
        searchingAuthor.SurName.Should().Be(author.SurName);
        searchingAuthor.Birthdate.Should().Be(author.Birthdate);
        searchingAuthor.Name.Should().Be(author.Name);

    }

}