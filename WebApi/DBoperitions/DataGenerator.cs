using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBoperitions;
public class DataGenerator{
    public static void Initialize(IServiceProvider serviceProvider){
        using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
        {
            if (context.Books.Any()){
                return;
            }

            List<Book> bookList = new(){
                new Book { Title="Lean Startup",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
                new Book { Title="Dune",GenreId = 2,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
                new Book { Title="Think and grow rich",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
            };
            List<Book> bookList2 = new(){new Book { Title="Billoners",GenreId = 3,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 2},
            new Book { Title="Rich Dad,Poor Dad",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 2}} ;
            context.Genres.AddRange(
                new  Genre(){Name = "Personel Growth"},
                new  Genre(){Name = "Science  Fiction"},
                new  Genre(){Name = "Romance"}
            );

            context.Books.AttachRange(bookList);
            context.Books.AttachRange(bookList2);
            
            context.Authors.AddRange(
                new Author(){Name = "Mustafa", SurName = "Kutlu",Birthdate = new DateTime(1999,01,12),Books = bookList},
                new Author(){Name = "Sabahattin",SurName = "Ali",Birthdate = new DateTime(1907,02,25),Books = bookList2}
            );
            context.SaveChanges();

        }
    }
}