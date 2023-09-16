using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DataBase.Dtos;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "Campo logradouro obrigatório!")]
    [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
    public string Logradouro { get; set; }
    
    [Required(ErrorMessage = "Campo número obrigatório!")] 
    public int Numero { get; set; }
}