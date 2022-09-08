using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Tags : EntityBase
{
    public string? TagName { get; set; }

    public Book? BookTagged { get; set; }
}
