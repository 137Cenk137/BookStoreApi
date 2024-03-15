using Microsoft.EntityFrameworkCore;

namespace WebApi.DBoperitions;
public class DataGenerator{
    public static void Initialize(IServiceProvider serviceProvider){
        using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
        {
            if (context.Books.Any()){
                return;
            }
            context.Books.AddRange( 
            new Book { Title="Lean Startup",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12)},
            new Book { Title="Dune",GenreId = 2,PageCount = 200,PublishDate = new DateTime(2001,06,12)},
            new Book { Title="Think and grow rich",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12)},
            new Book { Title="Billoners",GenreId = 3,PageCount = 200,PublishDate = new DateTime(2001,06,12)},
            new Book { Title="Rich Dad,Poor Dad",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12)}
        ); 
            context.SaveChanges();

        }
    }
}