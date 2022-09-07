using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

[Table("TBBorrowment")]
public class Borrowment
{
    [JsonPropertyName("date_borrowed")]
    public DateTime? DateBorrowment { get; set; }

    [JsonPropertyName("returning_date")]
    public DateTime? ReturningDate { get; set; }

    [JsonPropertyName("days_borrowed")]
    public long? DaysBorrowed { get; set; }

    [JsonPropertyName("renewable")]
    public bool? Renewable { get; set; }

    [ForeignKey(nameof(Book))]
    public Guid? BookId { get; set; }

    [ForeignKey(nameof(Person))]
    public Guid? BorrowerId { get; set; }
}