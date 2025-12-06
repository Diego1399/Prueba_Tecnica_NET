namespace ProyectoEvaluacion.Models
{
    public partial class UsuarioGrupo
    {
        public int IdUsuario { get; set; }
        public string CodRol { get; set; } = null!;

        public virtual Rol CodRolNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    }
}
