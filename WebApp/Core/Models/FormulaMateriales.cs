using System.ComponentModel.DataAnnotations;

namespace ProyectoEvaluacion.Models
{
    public partial class FormulaMateriales
    {
        public int IdFormula { get; set; }

        [Required(ErrorMessage = "El producto del material es requerido")]
        public int IdProducto { get; set; }

        public int Linea { get; set; }

        [Required(ErrorMessage = "El nombre del material es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0.01, 999999.99, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }

        // Propiedades de navegación
        public virtual Formula IdFormulaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;

    }

}
