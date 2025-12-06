using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEvaluacion.Models
{
    public partial class Formula
    {
        public Formula()
        {
            FormulaMateriales = new HashSet<FormulaMateriales>();
        }

        public int IdFormula { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0.01, 999999.99, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }

        public int IdUsuarioCreacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        // Propiedades de navegación
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;
        public virtual ICollection<FormulaMateriales> FormulaMateriales { get; set; }

    }
}
