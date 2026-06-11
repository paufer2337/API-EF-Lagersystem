using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.Data;
using StorageApi.DTOs;
using StorageApi.Models;

namespace StorageApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StorageContext _context;

    public ProductsController(StorageContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(string? category)
    {
        IQueryable<Product> products = _context.Products;

        if (!string.IsNullOrWhiteSpace(category))
            {
                products = products.Where(product => product.Category == category);
            }

        return await products
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count
            })
            .ToListAsync();
    }

    [HttpGet("stats")]
    public async Task<ActionResult<object>> GetProductStats()
    {
        var products = await _context.Products.ToListAsync();

        int totalProducts = products.Sum(product => product.Count);
        int totalInventoryValue = products.Sum(product => product.Price * product.Count);
        double averagePrice = products.Any() ? products.Average(product => product.Price) : 0;

        return Ok(new
        {
            totalProducts,
            totalInventoryValue,
            averagePrice
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        Product? product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return ToProductDto(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProductDto)
    {
        Product product = new Product
        {
            Name = createProductDto.Name,
            Price = createProductDto.Price,
            Category = createProductDto.Category,
            Shelf = createProductDto.Shelf,
            Count = createProductDto.Count,
            Description = createProductDto.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, ToProductDto(product));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        Product? product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(product => product.Id == id);
    }

    private static ProductDto ToProductDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Count = product.Count
        };
    }
}
