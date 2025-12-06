using System.Collections.Generic;

namespace ProyectoEvaluacion.Models
{
    public class Formula
    {
        public int IdFormula { get; set; }

        public List<Producto> oProducto { get; set; }

        public string Nombre { get; set; }
        public float Cantidad { get; set; }

        public string FechaCreacion { get; set; }
        public string FechaActualizacion { get; set; }

        
        public Usuario oUsuarioCreacion { get; set; }
        public Usuario oUsuarioActualizacion { get; set; }
    }
}
