using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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


    // convertir imagen a base 64
    private string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
        string base64String = Convert.ToBase64String(imageBytes);
        return base64String;
    }
}
