using AutoMapper;
using MilesCarRental.Application.Features.Carro.Commands.CreateCarro;
using MilesCarRental.Application.Features.Carro.Commands.UpdateCarro;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using MilesCarRental.Application.Features.EstadoAlquiler.Commands.CreateEstadoAlquiler;
using MilesCarRental.Application.Features.EstadoAlquiler.Commands.UpdateEstadoAlquiler;
using MilesCarRental.Application.Features.Localidad.Commands.CreateLocalidad;
using MilesCarRental.Application.Features.Localidad.Commands.UpdateLocalidad;
using MilesCarRental.Application.Features.TipoDocumento.Commands.CreateTipoDocumento;
using MilesCarRental.Application.Features.TipoDocumento.Commands.UpdateTipoDocumento;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.EstadoAlquiler;
using MilesCarRental.Application.Models.Localidad;
using MilesCarRental.Application.Models.TipoDocumento;
using MilesCarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Mappings
{
    /// <summary>
    /// Mapeo de clases que hacen el match de los datos
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCarroCommand, Carro>();
            CreateMap<UpdateCarroCommand, Carro>();
            CreateMap<Carro, CarroVm>();

            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<UpdateClienteCommand, Cliente>();
            CreateMap<Cliente, ClienteVm>();

            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();
            CreateMap<UpdateTipoDocumentoCommand, TipoDocumento>();
            CreateMap<TipoDocumento, TipoDocumentoVm>();

            CreateMap<CreateEstadoAlquilerCommand, EstadoAlquiler>();
            CreateMap<UpdateEstadoAlquilerCommand, EstadoAlquiler>();
            CreateMap<EstadoAlquiler, EstadoAlquilerVm>();

            CreateMap<CreateLocalidadCommand, Localidad>();
            CreateMap<UpdateLocalidadCommand, Localidad>();
            CreateMap<Localidad, LocalidadVm>();
        } 
    }
}
