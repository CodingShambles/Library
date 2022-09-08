namespace Entities.DTO;

public class BookDto
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Series { get; set; }
    public string? Publisher { get; set; }
    public string? PublishingYear { get; set; }
    public string? Isbn { get; set; }
    public string? Language { get; set; }
    public long? TotalVolumes { get; set; }
    public long? Available { get; set; }
}