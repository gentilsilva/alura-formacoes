using AutoMapper;
using FilmesApi.DataBase;
using FilmesApi.DataBase.Dtos;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionandoEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarEnderecoPorId([FromRoute] int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

        return Ok(enderecoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco([FromRoute] int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco([FromRoute] int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        _context.Remove(endereco);
        _context.SaveChanges();

        return NoContent();
    }
}