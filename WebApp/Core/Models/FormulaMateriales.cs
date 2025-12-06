namespace ProyectoEvaluacion.Models
{
    public class FormulaMateriales
    {
        public int IdFormula { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Linea { get; set; }
        public decimal Cantidad { get; set; }

        public Formula oFormula { get; set; }
        public Producto oProducto { get; set; }
    }

}
