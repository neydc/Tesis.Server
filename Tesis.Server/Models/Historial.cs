namespace Tesis.Server.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdMascota { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha{ get; set; }
    }
}
