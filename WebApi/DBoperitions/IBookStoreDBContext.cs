using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBoperitions;

public interface IBookStoreDBContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Author>   Authors { get; set; }

    DbSet<User> users{ get; set; }
    int SaveChanges(); 
}