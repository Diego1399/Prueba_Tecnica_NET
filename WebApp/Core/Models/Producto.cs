namespace ProyectoEvaluacion.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Formulas = new HashSet<Formula>();
            FormulaMateriales = new HashSet<FormulaMateriales>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Formula> Formulas { get; set; }
        public virtual ICollection<FormulaMateriales> FormulaMateriales { get; set; }

    }
}
