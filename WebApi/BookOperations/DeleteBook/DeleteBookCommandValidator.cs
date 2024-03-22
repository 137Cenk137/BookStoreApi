using System.ComponentModel;
using FluentValidation;
using WebApi.DBoperitions;

namespace WebApi.BookOperations.DeleteBook;

public class  DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    { 
        RuleFor(command => command.Id).GreaterThan(0);  
    }
}