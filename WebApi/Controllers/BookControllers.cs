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
    private  readonly BookStoreDBContext _context;//readonly yapılar constructor da set edilen degiskeni bir daha set edilmesini önler yanı bir kere set edilebilir  
    public BookController(BookStoreDBContext context)
    {
        _context = context; 
    }

    [HttpGet]
    public IActionResult GetAllBooks(){
       GetBookQuery query= new GetBookQuery(_context);
       var result = query.Handle();

       return Ok(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id){ 
         GetBookDetailQuery bookDetailQuery = new(_context){BookId = id}; 
         GetBookDetailQueryResponseViewModel results;
        try
        {
              results = bookDetailQuery.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
        
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
        CreateBookCommand createBook = new(_context);
        try
        {
            createBook.Model = newbook;
            createBook.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }

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

        try
        {
            UpdateBookCommand book = new UpdateBookCommand(_context){Id = id,Model = updateBook};

            book.Handle();
        
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
        
        return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBookById(int id){

        try
        {
            DeleteBookCommand delete = new(_context){Id = id};
            delete.Handle();
        }
        catch (Exception ex )
        {
            
            return BadRequest(ex.Message );
        }
         

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