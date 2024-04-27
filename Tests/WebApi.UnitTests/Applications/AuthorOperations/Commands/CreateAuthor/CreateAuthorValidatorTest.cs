using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using Xunit;
namespace Tests.Applications.AuthorOperations.Commands.CreateAuthor;


public class CreateAuthorValidatorTest 
{
    [Theory]
    [InlineData("","")]
    [InlineData("","a")]
    [InlineData("","as")]
    [InlineData("","asd")]
    [InlineData("","adff")]
    [InlineData("a","")]
    [InlineData("a","d")]
    [InlineData("a","ds")]
    [InlineData("a","dfs")]
    [InlineData("a","asfa")]
    [InlineData("ab","")]
    [InlineData("ab","f")]
    [InlineData("ab","fe")]
    [InlineData("ab","wrf")]
    [InlineData("ab","wfrf")]
    [InlineData("abd","")]
    [InlineData("abd","d")]
    [InlineData("abd","sd")]
    [InlineData("abd","dff")]
    [InlineData("abd","sdff")]
    [InlineData("abdf","")]
    [InlineData("abdf","b")]
    [InlineData("abdf","ws")]
    [InlineData("abdf","fvv")]
  
    
    public void WhenInvalidAreGivenExceptDateTime_Validator_ShouldBeReturnErrors(string shamSurname,string shamName)
    {
        CreateAuthorModel model = new (){SurName = shamSurname,Name = shamName, Birthdate = DateTime.Now.Date.AddYears(-10)};
        CreateAuthorCommand command = new CreateAuthorCommand(null,null){Model = model};
        CreateAuthorValidator validator = new CreateAuthorValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);

    }

    [Fact]
    public void WhenBirthdateAreGivenWronf_Validator_ShouldBeReturnError()
    {
         CreateAuthorModel model = new (){SurName ="werty" ,Name ="sdfgtyhu" , Birthdate = DateTime.Now};
        CreateAuthorCommand command = new CreateAuthorCommand(null,null){Model = model};
        CreateAuthorValidator validator = new CreateAuthorValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
}