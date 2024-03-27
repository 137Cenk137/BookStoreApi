using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre;


public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreValidator()
    {
        RuleFor(Command => Command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
        RuleFor(Command => Command.Id).GreaterThan(0);
        

    }
}