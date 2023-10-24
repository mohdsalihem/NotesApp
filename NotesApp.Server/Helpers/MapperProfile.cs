using AutoMapper;
using NotesApp.Server.Dtos;
using NotesApp.Server.Models;

namespace NotesApp.Server.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignupRequestDto, User>();
        CreateMap<NoteRequestDto, Note>();
    }
}
