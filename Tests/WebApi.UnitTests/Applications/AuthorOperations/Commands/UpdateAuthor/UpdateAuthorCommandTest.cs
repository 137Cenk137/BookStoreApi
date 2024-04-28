


using WebApi.DBoperitions;
using TestsSetup;

using Xunit;
using AutoMapper;
using WebApi.Applications.AuthorOperations.Command.UpdateAuthor;
using FluentAssertions;
using WebApi;
namespace Tests.Applications.AuthorOperations.Commands.UpdateAuthor;
public class UpdateAuthorCommandTest: IClassFixture<CommanTestFixture>
{
    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandTest(CommanTestFixture testFixture)
    {
        _dbContext = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenIdNotExist_InvalidOperationException_ShouldBeReturn()
    {
        UpdateAuthorCommand command =  new(_dbContext,_mapper){AuthorId = 234};
        FluentActions.Invoking(()=> command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");



    }

    [Fact]
    public void WhenUpdateSucced_ShoulBeReturnCorrect()
    {
        

        UpdateAuthorModel model = new(){Name = "wedfg",SurName = "erfgf"};


        UpdateAuthorCommand command =  new(_dbContext,_mapper){AuthorId= 2,Model = model};
        FluentActions.Invoking(()=> command.Handle()).Invoke();


        command.Model.SurName.Should().Be(model.SurName);
        command.Model.Name.Should().Be(model.Name);
        


    }
    
}