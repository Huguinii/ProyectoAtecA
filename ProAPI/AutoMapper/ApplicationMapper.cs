
using AutoMapper;
using RestAPI.Models.DTOs;
using RestAPI.Models.DTOs;
using RestAPI.Models.DTOs.UserDto;



//using RestAPI.Models.DTOs.LibroDTO;
using RestAPI.Models.Entity;

namespace RestAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();

            CreateMap<ReservaDTO, ReservaEntity>().ReverseMap();
            CreateMap<CreateReservaDTO, ReservaEntity>().ReverseMap();
            
            CreateMap<DiaDTO, DiaEntity>().ReverseMap();
            CreateMap<CreateDiaDTO, DiaEntity>().ReverseMap();

            CreateMap<FranjaHorariaDTO, FranjaHorariaEntity>().ReverseMap();
            CreateMap<CreateFranjaHorariaDTO, FranjaHorariaEntity>().ReverseMap();
            

        }
    }
}
