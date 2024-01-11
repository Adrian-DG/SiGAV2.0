using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO.Usuario;
using Domain.Entities.Usuario;

namespace Domain.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UserRegisterDTO, Usuario>()
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => src.username)
                )
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.nombre)
                )
                .ForMember(
                    dest => dest.Apellido,
                    opt => opt.MapFrom(src => src.apellido)
                )
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => true)
                )
                .ForMember(
                    dest => dest.DepartamentoId,
                    opt => opt.MapFrom(src => src.departmentoId)
                );
        }
    }
}