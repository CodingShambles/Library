using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Person : EntityBase
{
    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Address? Address { get; set; }

    public Roles? Role { get; set; }

    public long? BookBorrowLimit { get; set; }


    public Book? BookBorrowed { get; set; }
}