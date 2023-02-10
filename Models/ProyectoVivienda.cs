namespace prueba_tecnica_proyectos_vivienda.Models
{
    public class ProyectoVivienda
    { 
        public int id { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_entrega { get; set; }
        public string area { get; set; }
        public float precio { get; set; }
        public Boolean estado { get; set; }
        public int constructora_id { get; set; }
        public string tipo_proyecto { get; set; }
    }
}
