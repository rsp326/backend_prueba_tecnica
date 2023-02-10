using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using prueba_tecnica_proyectos_vivienda.Models;

namespace prueba_tecnica_proyectos_vivienda.Controllers
{
    [Route("api/ProyectoVivienda")]
    [ApiController]
    public class ProyectoViviendaController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=proyectos_de_vivienda; Uid=root; Password=1234; Port=3306;";
        [HttpGet]
        public IActionResult consultaProyectos()
        {
            IEnumerable<Models.ProyectoVivienda> listaProyectos = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from proyecto where estado=1";
                listaProyectos = db.Query<Models.ProyectoVivienda>(sql);
            }
            return Ok(listaProyectos);
        }

        [HttpGet("{id}")]
        public IActionResult consultaProyecto(int id)
        {
            IEnumerable<Models.ProyectoVivienda> proyecto = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from proyecto where id=" + id;
                proyecto = db.Query<Models.ProyectoVivienda>(sql);
            }
            return Ok(proyecto);
        }

        [HttpPost]
        public IActionResult insertarProyecto(ProyectoVivienda proyecto)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {

                var sql = "insert into proyecto (direccion,contacto,nombre,fecha_inicio,fecha_entrega,area,precio,estado,constructora_id,tipo_proyecto)" +
                    "values(@direccion,@contacto,@nombre,@fecha_inicio,@fecha_entrega,@area,@precio,@estado,@constructora_id,@tipo_proyecto)";
                resultado = db.Execute(sql, proyecto);
            }
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult actualizarProyecto(ProyectoVivienda proyecto)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {

                var sql = "update proyecto set " +
                    "direccion=@direccion,contacto=@contacto,nombre=@nombre,fecha_inicio=@fecha_inicio,fecha_entrega=@fecha_entrega,area=@area,precio=@precio,estado=@estado," +
                    "constructora_id=@constructora_id,tipo_proyecto=@tipo_proyecto  where id=@id";

                resultado = db.Execute(sql, proyecto);
            }
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public IActionResult eliminarProyecto(int id)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "update proyecto set estado=0 where id=" + id;

                resultado = db.Execute(sql);
            }
            return Ok(resultado);
        }


    }
}
