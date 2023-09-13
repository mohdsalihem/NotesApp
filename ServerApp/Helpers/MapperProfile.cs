using AutoMapper;
using ServerApp.Dtos;
using ServerApp.Models;

namespace ServerApp.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignupRequestDto, User>();
        CreateMap<NoteRequestDto, Note>();
    }
}
