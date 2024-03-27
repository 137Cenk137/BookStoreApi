
using FluentValidation;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0).LessThan(4);

                
    }
}