namespace WebAPI_Carlos_Chica_20261113.Entity
{
    public class RegistroEvento
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
