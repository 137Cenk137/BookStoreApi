using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperitions;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController:ControllerBase
{
    private  readonly IBookStoreDBContext _context;//readonly yapılar constructor da set edilen degiskeni bir daha set edilmesini önler yanı bir kere set edilebilir  
    private readonly IMapper _mapper;
    public BookController(IBookStoreDBContext context, IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllBooks(){
       GetBookQuery query= new GetBookQuery(_context,_mapper);
       var result = query.Handle();

       return Ok(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id){ 
         GetBookDetailQuery bookDetailQuery = new(_context,_mapper){BookId = id}; 
         GetBookDetailQueryResponseViewModel results;
       
            GetBookDetailQueryValidator validations = new(_context);
            validations.ValidateAndThrow(bookDetailQuery);
            results = bookDetailQuery.Handle();
        
        
       return Ok(results);
    }

    //[HttpGet]
    //public Book GetById([FromQuery] string id){
      // var bookList =  books.Find(p => p.Id == Convert.ToInt32(id));
       //return bookList; 
    //}
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newbook)
    {
        CreateBookCommand createBook = new(_context,_mapper);
        
            createBook.Model = newbook;
            CreateBookCommandValidator validations = new();
            //ValidationResult result = validations.Validate(createBook); 
            validations.ValidateAndThrow(createBook);
            createBook.Handle();
            // if (result.IsValid){
            //     foreach (var item in result.Errors)
            //     {
            //         Console.WriteLine("Ozellik" + item.PropertyName + "- error Message" + item.ErrorMessage);
            //     }
            // }

            // else
            // {createBook.Handle();}
        
       

        return Ok();
    }

//put o
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook){
        //var book = _context.Books.SingleOrDefault(p =>p.Id == id);

        //if (book is  null){return BadRequest();}

        //book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
        //book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
        //book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
        //book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;

        //_context.SaveChanges();

        
            UpdateBookCommand book = new UpdateBookCommand(_context){Id = id,Model = updateBook};
            UpdateBookCommandValidator validations = new();

            validations.ValidateAndThrow(book);
            book.Handle();
       
        return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBookById(int id){

        
            DeleteBookCommand delete = new(_context){Id = id};
            DeleteBookCommandValidator validations = new();
            validations.ValidateAndThrow(delete);
            delete.Handle();
        
         

        return Ok();
        
    }

    private static string HandleExceptions(Action action){
        try
        {
            action.Invoke();
            return " ";
        }
        catch (Exception ex )
        {
             return ex.Message;
            
        }
        
    }

}