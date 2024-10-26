using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Seguridad.Usuario
{
    public class UsuarioImprimirDto : UsuarioDto
    {     
        public required string RolDescripcion { get; set; }
        public required string NombreCompletoDescripcion { get; set; }
 
    }
}
