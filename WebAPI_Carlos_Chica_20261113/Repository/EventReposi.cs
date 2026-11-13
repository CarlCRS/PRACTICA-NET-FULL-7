using Dapper;
using System.Data;
using WebAPI_Carlos_Chica_20261113.Entity;

namespace WebAPI_Carlos_Chica_20261113.Repository
{
    public class EventReposi
    {
        private readonly IDbConnection _db;

        public EventReposi(IDbConnection dbs) {
            _db = dbs;
        }

        public async Task<IEnumerable<Evento>> ObtenerTodasAsync()
        {
            var sql = @"SELECT * FROM Evento;";
            return await _db.QueryAsync<Evento>(sql);
        }

        public async Task<Evento?> ObtenerPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM dbo.Evento WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<Evento>(sql, new { Id = id });
        }

        public async Task<int> CrearAsync(Evento eventos)
        {

            var sql = @"
            VALUES (@title, @descripcion, @fechainicio, @fechafin, @ubicacion,@organizadorID);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            return await _db.ExecuteScalarAsync<int>(sql, eventos);
        }

        public async Task ActualizarAsync(Evento eventos)
        {
            var sql = @"UPDATE dbo.Evento 
                    SET title = @title, descripcion = @descripcion, fechainicio = @fechainicio, fechafin = @fechafin, ubicacion = @ubicacion,organizadorID = @organizadorID ,  
                    WHERE Id = @Id";

            await _db.ExecuteAsync(sql, eventos);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var sql = "DELETE FROM dbo.Evento Id = @Id";
            var filasAfectadas = await _db.ExecuteAsync(sql, new { Id = id });
            return filasAfectadas > 0;
        }



    }
}
