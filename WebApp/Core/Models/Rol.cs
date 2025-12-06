namespace ProyectoEvaluacion.Models
{
    public partial class Rol
    {
        public Rol()
        {
            UsuarioGrupo = new HashSet<UsuarioGrupo>();
        }

        public string CodRol { get; set; } = null!;
        public string Rol1 { get; set; } = null!;

        public virtual ICollection<UsuarioGrupo> UsuarioGrupo { get; set; }

    }
}
