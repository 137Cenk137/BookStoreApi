using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Query.GetAuthorDetail;

public class GetAuthorDetaikValidator : AbstractValidator<GetAuthorDetailQuery>
{
    public GetAuthorDetaikValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}