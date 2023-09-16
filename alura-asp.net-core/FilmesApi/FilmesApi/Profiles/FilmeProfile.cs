using AutoMapper;
using FilmesApi.DataBase.Dtos;
using FilmesApi.models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{

    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
    
}