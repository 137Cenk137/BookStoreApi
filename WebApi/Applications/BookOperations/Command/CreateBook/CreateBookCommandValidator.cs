using AutoMapper;
using FluentValidation;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Model.GenreId).GreaterThan(0).LessThan(4);
        RuleFor(command => command.Model.PageCount).GreaterThan(0);
        RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(commad => commad.Model.Title).NotEmpty().MinimumLength(4);
    }
}