namespace ProyectoEvaluacion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioGrupos = new HashSet<UsuarioGrupo>();
            FormulaIdUsuarioActualizacionNavigations = new HashSet<Formula>();
            FormulaIdUsuarioCreacionNavigations = new HashSet<Formula>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string ContraseñaHash { get; set; } = null!;

        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual ICollection<Formula> FormulaIdUsuarioActualizacionNavigations { get; set; }
        public virtual ICollection<Formula> FormulaIdUsuarioCreacionNavigations { get; set; }

    }
}
