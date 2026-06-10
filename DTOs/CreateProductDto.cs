using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Price { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Shelf { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Count { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;
}
