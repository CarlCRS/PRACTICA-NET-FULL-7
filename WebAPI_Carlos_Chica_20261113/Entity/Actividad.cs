namespace WebAPI_Carlos_Chica_20261113.Entity
{
    public class Actividad
    {
            public int Id { get; set; }
            public int EventoId { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public DateTime Fecha { get; set; }
            public DateTime TiempoInicio { get; set; }
            public DateTime TiempoFin { get; set; }
        }
}
