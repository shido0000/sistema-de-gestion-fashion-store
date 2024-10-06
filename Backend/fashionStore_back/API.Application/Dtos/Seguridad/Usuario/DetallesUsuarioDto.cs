namespace API.Application.Dtos.Seguridad.Usuario
{
    public class DetallesUsuarioDto : UsuarioDto
    {
        public required string Rol { get; set; }

        public required string RolDescripcion { get; set; }

    }
}
