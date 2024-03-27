using FluentValidation;

namespace WebApi.Applications.GenreOperations.Query.GetGenres;

public class GetGenresDetailQueryValidator : AbstractValidator<GetGenresDetailQuery>
{
    public GetGenresDetailQueryValidator()
    {
        RuleFor(Query => Query.GenreId).GreaterThan(0);
        
    }
}