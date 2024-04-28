using WebApi;
using WebApi.DBoperitions;

namespace TestsSetup;
public static class Authors
{
    public static void AddAuthors(this BookStoreDBContext context)
    {
        context.Authors.AddRange( 
            new Author {Name = "pelin",SurName = "kose"},
            new Author {Name = "pelin",SurName = "kose"},
            new Author { Name = "pelin", SurName = "kose" },
            new Author {Name = "pelin",SurName = "kose"},
            new Author {Name = "pelin",SurName = "kose"}
        );

    }
}