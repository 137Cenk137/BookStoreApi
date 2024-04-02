namespace TestsSetup;
using WebApi.DBoperitions;
using WebApi.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CommanTestFixture
{
   public BookStoreDBContext Context {get; set;}
   public IMapper Mapper {get;set;} 

   public CommanTestFixture()
   {
      var options = new DbContextOptionsBuilder<BookStoreDBContext>().UseInMemoryDatabase(databaseName : "BookStoreTestDB").Options;
      Context = new BookStoreDBContext(options);
      Context.Database.EnsureCreated(); 
      Context.AddBooks();
      Context.AddGenres();
      Context.SaveChanges();

      Mapper = new MapperConfiguration ( cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
   }
}