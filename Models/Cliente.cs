using System.Text.Json.Serialization;

namespace prueba_tecnica_proyectos_vivienda.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public int numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nombre_cliente { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public Boolean estado { get; set; }
        public int usuario_id { get; set; }
        public int proyecto_id { get; set; }

    }
}
