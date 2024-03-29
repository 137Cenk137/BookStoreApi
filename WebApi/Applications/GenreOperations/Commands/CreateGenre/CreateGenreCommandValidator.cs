using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(Query => Query.Model.Name).NotEmpty().MinimumLength(4);
        
    }
}