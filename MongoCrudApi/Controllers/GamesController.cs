using Microsoft.AspNetCore.Mvc;
using MongoCrudApi.Models;
using MongoCrudApi.Services;

namespace MongoCrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameService _gameService;

    public GamesController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> Get() =>
        await _gameService.GetAllAsync();

    [HttpGet("{id:length(24)}", Name = "GetGame")]
    public async Task<ActionResult<Game>> Get(string id)
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null) return NotFound();
        return game;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Game newGame)
    {
        await _gameService.CreateAsync(newGame);
        return CreatedAtRoute("GetGame", new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Game updatedGame)
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null) return NotFound();

        updatedGame.Id = game.Id;
        await _gameService.UpdateAsync(id, updatedGame);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null) return NotFound();

        await _gameService.RemoveAsync(id);
        return NoContent();
    }

    // Endpoint de Agregação
    [HttpGet("statistics")]
    public async Task<ActionResult<List<GameStatsDto>>> GetStatistics()
    {
        var stats = await _gameService.GetGamesStatisticsByGenreAsync();
        return Ok(stats);
    }
}