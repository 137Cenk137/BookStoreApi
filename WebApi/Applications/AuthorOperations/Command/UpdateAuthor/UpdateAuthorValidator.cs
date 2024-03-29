using System.Data;
using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorValidator()
    {
        RuleFor(x => x.Model.SurName).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
        RuleFor(x =>x.AuthorId).NotEmpty().GreaterThan(0);
    }
}