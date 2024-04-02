using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace WebApi;
//csproj dosyasına elle ekleyebliiriz paket referanslarını ama sonra terminalde   dotnet restore çalistirmaliyız 
// büyük bir projede bunları git pushladımızda pull projeyi çekecekler csproj dosyasına paket referanslarını ekleyip dotnet reStore çalistirmalilar
public class Book{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//primeray ke yapar
    public int Id { get; set; }
    public string Title { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public Author Author{ get; set; }
    public int AuthorId  { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }

    
}