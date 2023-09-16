using AutoMapper;
using FilmesApi.DataBase;
using FilmesApi.DataBase.Dtos;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperarCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId([FromRoute] int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        
        return Ok(cinemaDto);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinemaPorId([FromRoute] int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema([FromRoute] int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        
        if (cinema == null) return NotFound();
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();

        return NoContent();
    }
}