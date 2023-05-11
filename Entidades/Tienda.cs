namespace TiendaAPi.Entidades
{
    public class Tienda
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaApertura { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
