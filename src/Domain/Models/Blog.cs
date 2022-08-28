using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Blog : ModelBase
{
    public string Title { get; set; }

    public string Text { get; init; }

    public string Url { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}