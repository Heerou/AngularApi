using AutoMapper;
using BackEndApi.DTOs;
using BackEndApi.Models;
using System.Globalization;

namespace BackEndApi.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            #region Persona
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            #endregion
        }
    }
}
