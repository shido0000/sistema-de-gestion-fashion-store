using API.Application.Mapper.Gestion.Nomencladores;
using API.Application.Mapper.Pago.Nomencladores;
using API.Application.Mapper.Seguridad;
using AutoMapper;

namespace API.Application.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMappers(this IServiceCollection services, MapperConfigurationExpression cfg)
        {
            IMapper mapper = new MapperConfiguration(cfg).CreateMapper();
            services.AddSingleton(mapper);
        }
        public static MapperConfigurationExpression AddAutoMapperLeadOportunidade(this MapperConfigurationExpression cfg)
        {
            cfg.AddProfile<UsuarioDtoProfile>();
            cfg.AddProfile<RolDtoProfile>();
            cfg.AddProfile<PermisoDtoProfile>();

            // GESTION
            cfg.AddProfile<ConversionPrecioDtoProfile>();
            cfg.AddProfile<EstadoProductoDtoProfile>();
            cfg.AddProfile<ProductoDtoProfile>();
            cfg.AddProfile<GestorDtoProfile>();
            cfg.AddProfile<VentaDtoProfile>();
            cfg.AddProfile<ValeDeVentaDtoProfile>();

            //PAGO
            cfg.AddProfile<PagoGestorDtoProfile>();


            return cfg;
        }
        public static MapperConfigurationExpression CreateExpression()
        {
            return new MapperConfigurationExpression();
        }
    }
}
