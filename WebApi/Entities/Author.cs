using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi;

public class Author
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorId { get; set; }
    public string Name { get; set;}
    public string? SurName { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<Book>? Books { get; set; }

}