using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DataBase.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")] 
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
}