namespace Domain.Models;

public class Blog : ModelBase
{
    public string Title { get; set; }

    public string Text { get; init; }

    public long AuthorId { get; set; }

    public int Likes { get; set; }

    public Author Author { get; set; }
}