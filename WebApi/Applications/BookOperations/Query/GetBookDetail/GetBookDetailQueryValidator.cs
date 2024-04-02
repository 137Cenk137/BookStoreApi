using AutoMapper;
using FluentValidation;
using WebApi.Common;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.GetBookDetail;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
    
    public GetBookDetailQueryValidator(IBookStoreDBContext dbContext)
    {

        RuleFor(query => query.BookId).NotEmpty().GreaterThan(0).LessThan(dbContext.Books.Count()+1);
    }
}