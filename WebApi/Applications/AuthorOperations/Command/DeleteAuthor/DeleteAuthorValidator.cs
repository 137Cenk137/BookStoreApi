using FluentValidation;
using WebApi.Applications.AuthorOperations.Command.DeleteAuthor;

namespace WebApi.Applications.AuthorOperations.Command.DeleteAuthor;
public class DeleteAuthorValidator: AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorValidator()
    {
       
        RuleFor(x=>x.AuthorId).NotEmpty().GreaterThan(0);
        

    }
}