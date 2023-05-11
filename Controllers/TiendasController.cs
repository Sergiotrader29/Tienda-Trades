using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]
public class TiendasController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TiendasController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public IActionResult GetProductos(int id)
    {
        var tienda = _dbContext.Tiendas.Include(t => t.Productos).FirstOrDefault(t => t.ID == id);
        if (tienda == null)
        {
            return NotFound();
        }

        var productos = tienda.Productos.Select(p => new
        {
            p.ID,
            p.Nombre,
            p.SKU,
            p.Descripcion,
            p.Valor,
            Imagen = ConvertImageToBase64(p.Imagen)
        });

        return Ok(productos);
    }

    private string ConvertImageToBase64(string imagePath)
    {
        // Lógica para convertir la imagen a base64
        // Aquí debes leer el archivo de imagen desde el sistema de archivos y convertirlo a base64
        return "base64_encoded_image";
    }
}
