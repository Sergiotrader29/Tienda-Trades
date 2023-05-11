namespace TiendaAPi.Entidades
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public string Imagen { get; set; }
        public int TiendaID { get; set; }
        public Tienda Tienda { get; set; }
    }
}
