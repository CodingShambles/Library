using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

[Table("Person")]
public class Person
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [JsonPropertyName("role")]
    public Roles? Role { get; set; }

    [JsonPropertyName("book_borrow_limit")]
    public long? BookBorrowLimit { get; set; }

    [JsonPropertyName("books_borrowed")]
    public ICollection<Book>? BooksBorrowed { get; set; }
}