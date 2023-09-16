using AutoMapper;
using FilmesApi.DataBase;
using FilmesApi.DataBase.Dtos;
using FilmesApi.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"> Objeto com os campos necessários para criação de um filme </param>
    /// <returns> IActionResult </returns>
    /// <response code="201"> Caso inserção seja feita com sucesso </response>
    /// <response code="400"> Caso inserção seja feita mal sucedida </response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Retorna uma lista de filmes
    /// </summary>
    /// <param name="skip"> Informa quantos filmes deseja pular </param>
    /// <param name="take"> Informa quantos filmes deseja mostrar </param>
    /// <returns> IActionResult </returns>
    /// <response code="200"> Caso retorne a lista </response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0,[FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um filme pelo Id
    /// </summary>
    /// <param name="id"> Id pertencente ao filme desejado </param>
    /// <returns> IActionResult </returns>
    /// <response code="200"> Caso filme seja encontrado </response>
    /// <response code="404"> Caso filme não exista </response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaFilmePorId([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Atualiza todos os campos de um filme no banco de dados pelo Id
    /// </summary>
    /// <param name="id"> Informa o id do filme que deseja atualizar </param>
    /// <param name="filmeDto"> Objeto com os campos necessários para criação de um filme </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> Caso atualização seja bem sucedida </response>
    /// <response code="404"> Caso filme não seja encontrado </response>
    /// <response code="400"> Caso atualização seja mal sucedida </response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilme([FromRoute] int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary>
    /// Atualiza de forma parcial um filme no banco de dados pelo Id
    /// </summary>
    /// <param name="id"> Informa o id do filme que deseja atualizar </param>
    /// <param name="patch"> Objeto com os campos necessários para criação de um filme </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> Caso atualização seja bem sucedida </response>
    /// <response code="404"> Caso filme não seja encontrado </response>
    /// <response code="400"> Caso atualização seja mal sucedida </response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilmeParcial([FromRoute] int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        /*
            Mappeia o filme para um UpdateFilmeDto
            Depois tenta validar os dados
            Se não for validado, retorna um valitationProblem.
         */
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um filme do banco de dados pelo Id
    /// </summary>
    /// <param name="id"> Informa o id do filme que deseja deletar </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> Caso deleção seja bem sucedida </response>
    /// <response code="404"> Caso filme não seja encontrado </response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaFilme([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        
        return NoContent();
    }
}