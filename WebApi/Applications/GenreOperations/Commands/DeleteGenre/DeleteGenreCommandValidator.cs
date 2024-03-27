
using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(p => p.GenreId).GreaterThan(0).LessThan(p => p._lenghtOfContext);
    }
}