using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TiendaAPi;

[Route("api/[controller]")]
[ApiController]
public class TiendasController : ControllerBase
{
    private readonly ApplicationDbContest _dbContext;
    private readonly ILogger<TiendasController> _logger;

    public TiendasController(ApplicationDbContest dbContext, ILogger<TiendasController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetProductos(int id)
    {
        _logger.LogInformation("Se ha llamado al método GetProductos");

        var tienda = _dbContext.Tiendas.Include(t => t.Productos).FirstOrDefault(t => t.ID == id);
        if (tienda == null)
        {
            _logger.LogWarning("No se encontró la tienda con ID: {ID}", id);
            return NotFound();
        }

        var productos = tienda.Productos.Select(p => new
        {
            TiendaNombre = tienda.Nombre,
            p.ID,
            p.Nombre,
            p.SKU,
            p.Descripcion,
            p.Valor,
            Imagen = ConvertImageToBase64(p.Imagen)
        });

        return Ok(productos);
    }

    // convertir imagen a base 64
    private string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
        string base64String = Convert.ToBase64String(imageBytes);
        return base64String;
    }
}
