using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPi;

[Route("api/[controller]")]
[ApiController]
public class TiendasController : ControllerBase
{
    private readonly ApplicationDbContest _dbContext;

    public TiendasController(ApplicationDbContest dbContext)
    {
        _dbContext = dbContext;
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductos(int id)
    {
        var tienda = await _dbContext.Tiendas.Include(t => t.Productos).FirstOrDefaultAsync(t => t.ID == id);
        if (tienda == null)
        {
            return NotFound();
        }

        var productos = tienda.Productos.Select(async p => new
        {
            TiendaNombre = tienda.Nombre,
            p.ID,
            p.Nombre,
            p.SKU,
            p.Descripcion,
            p.Valor,
            Imagen = await ConvertImageToBase64Async(p.Imagen)
        });

        return Ok(await Task.WhenAll(productos));
    }

    // convertir imagen a base 64
    private async Task<string> ConvertImageToBase64Async(string imagePath)
    {
        byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);
        string base64String = Convert.ToBase64String(imageBytes);
        return base64String;
    }
}
