using Microsoft.EntityFrameworkCore;

namespace WebApi.DBoperitions;

public interface IBookStoreDBContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Author>   Authors { get; set; }
    int SaveChanges(); 
}