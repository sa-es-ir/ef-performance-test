using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Blog : ModelBase
{
    public string Title { get; set; }

    public string Text { get; init; }

    public string Url { get; set; }

    public long AuthorId { get; set; }

    public Author Author { get; set; }
}