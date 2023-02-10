using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace prueba_tecnica_proyectos_vivienda.Controllers
{
    [Route("api/TipoDocumento")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=proyectos_de_vivienda; Uid=root; Password=1234; Port=3306;";
        [HttpGet]
        public IActionResult consultaProyectos()
        {
            IEnumerable<Models.TipoDocumento> listaTipoDocumento = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from tipo_documento";
                listaTipoDocumento = db.Query<Models.TipoDocumento>(sql);
            }
            return Ok(listaTipoDocumento);
        }






    }
}
