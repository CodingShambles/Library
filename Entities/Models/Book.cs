using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

[Table("TBBooks")]
public class Book
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("series")]
    public string? Series { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("publishing_year")]
    public string? PublishingYear { get; set; }
    
    [JsonPropertyName("isbn")]
    public string? Isbn { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("total_volumes")]
    public long? TotalVolumes { get; set; }

    [JsonPropertyName("available_volumes")]
    public long? AvailableVolumes { get; set; }
}