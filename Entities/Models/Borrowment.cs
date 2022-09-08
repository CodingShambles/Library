using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Borrowment : EntityBase
{
    public DateTime? DateBorrowment { get; set; }

    public DateTime? ReturningDate { get; set; }

    public long? DaysBorrowed { get; set; }

    public bool? Renewable { get; set; }


    public Book BorrowedBook { get; set; }

    public Person Borrower { get; set; }
}