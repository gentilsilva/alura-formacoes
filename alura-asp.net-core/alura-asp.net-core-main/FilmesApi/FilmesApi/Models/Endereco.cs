using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo logradouro obrigatório!")]
    [MaxLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres!")]
    public string Logradouro { get; set; }
    
    [Required(ErrorMessage = "Campo número obrigatório!")] 
    public int Numero { get; set; }
    
    public virtual Cinema Cinema { get; set; }
}