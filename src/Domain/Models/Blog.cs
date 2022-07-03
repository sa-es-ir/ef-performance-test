using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Blog : ModelBase
{
    public string Title { get; set; }

    public string Text { get; init; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}