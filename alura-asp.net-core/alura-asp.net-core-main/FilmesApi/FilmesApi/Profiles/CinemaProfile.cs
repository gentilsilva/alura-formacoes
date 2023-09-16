using AutoMapper;
using FilmesApi.DataBase.Dtos;
using FilmesApi.models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>().
            ForMember(cinemaDto => cinemaDto.Endereco, 
            opt => 
                opt.MapFrom(cinema => cinema.Endereco)); // Mapear o virtual Endereco da entidade
                                                                        // Endereco para ReadEnderecoDto
    }
}