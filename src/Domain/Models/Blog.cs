namespace Domain.Models;

public class Blog : ModelBase
{
    public string Title { get; set; }

    public string Text { get; set; }

    public long AuthorId { get; set; }

    public Author Author { get; set; }
}