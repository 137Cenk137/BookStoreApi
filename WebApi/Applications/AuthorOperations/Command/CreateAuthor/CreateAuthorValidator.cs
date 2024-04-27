using FluentValidation;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
namespace WebApi.Applications.AuthorOperations.Command.CreateAuthor;
public class CreateAuthorValidator: AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorValidator()
    {
        RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
        RuleFor(x=>x.Model.SurName).NotEmpty().MinimumLength(4);
        RuleFor(x=>x.Model.Birthdate).NotEmpty().LessThan(DateTime.Now.Date);

    }
}