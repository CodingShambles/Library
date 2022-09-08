namespace Entities.DTO;

public class PersonDto
{
    public string? Name { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public AddressDto? AddressDto { get; set; }
    public ICollection<BookDto>? BooksBorrowed { get; set; }
}