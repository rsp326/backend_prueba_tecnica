using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using prueba_tecnica_proyectos_vivienda.Models;

namespace prueba_tecnica_proyectos_vivienda.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=proyectos_de_vivienda; Uid=root; Password=1234; Port=3306;";
        [HttpGet]
        public IActionResult consultaClientes()
        {
            IEnumerable <Models.Cliente> listaCliente = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from cliente where estado=1";
                listaCliente = db.Query< Models.Cliente> (sql);
            }
            return Ok (listaCliente);
        }

        [HttpGet("{numeroDocumento}")]
        public IActionResult consultaCliente(int numeroDocumento)
        {
            IEnumerable<Models.Cliente> cliente = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from cliente where numero_documento="+numeroDocumento;
                cliente = db.Query<Models.Cliente>(sql);
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult insertarCliente(Cliente cliente)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {
      
                var sql = "insert into cliente (numero_documento,tipo_documento,nombre_cliente,telefono,direccion,email,fecha_nacimiento,estado,usuario_id,proyecto_id)" +
                    "values(@numero_documento,@tipo_documento,@nombre_cliente,@telefono,@direccion,@email,@fecha_nacimiento,@estado,@usuario_id,@proyecto_id)";
                resultado = db.Execute(sql,cliente);
            }
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult actualizarCliente(Cliente cliente)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {

                var sql = "update cliente set " +
                    "numero_documento=@numero_documento,tipo_documento=@tipo_documento,nombre_cliente=@nombre_cliente," +
                    "telefono=@telefono,direccion=@direccion,email=@email,fecha_nacimiento=@fecha_nacimiento," +
                    "estado=@estado,usuario_id=@usuario_id,proyecto_id=@proyecto_id where id=@id";

                resultado = db.Execute(sql, cliente);
            }
            return Ok(resultado);
        }

        [HttpPut("{numeroDocumento}")]
        public IActionResult eliminarCliente(int numeroDocumento)
        {
            int resultado = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "update cliente set estado=0 where numero_documento=" + numeroDocumento; 
                  

                resultado = db.Execute(sql);
            }
            return Ok(resultado);
        }


    }
}
