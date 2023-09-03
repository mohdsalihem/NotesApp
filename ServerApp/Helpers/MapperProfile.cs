using AutoMapper;
using ServerApp.Entities;
using ServerApp.Models;

namespace ServerApp.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignupRequest, User>();
        CreateMap<NoteRequest, Note>();
    }
}
