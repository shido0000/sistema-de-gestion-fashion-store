using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Gestor
{
    public class GestorDto : EntidadBaseDto
    {
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }

    }
}
