using WebApi;
using WebApi.DBoperitions;

namespace TestsSetup;
public static class Books
{
    public static void AddBooks(this BookStoreDBContext context)
    {
        context.Books.AddRange( 
            new Book { Title="Lean Startup",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
            new Book { Title="Dune",GenreId = 2,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
            new Book { Title="Think and grow rich",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 1},
            new Book { Title="Billoners",GenreId = 3,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 2},
            new Book { Title="Rich Dad,Poor Dad",GenreId = 1,PageCount = 200,PublishDate = new DateTime(2001,06,12),AuthorId = 2}
        );

    }
}