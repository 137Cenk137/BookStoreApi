using WebApi;
using WebApi.DBoperitions;

namespace TestsSetup;
public static class Genres
{
    public static void AddGenres(this BookStoreDBContext context)
    {
          context.Genres.AddRange(
                new  Genre(){Name = "Personel Growth"},
                new  Genre(){Name = "Science  Fiction"},
                new  Genre(){Name = "Romance"}
            );
    }
}