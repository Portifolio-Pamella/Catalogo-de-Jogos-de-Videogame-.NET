using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoCrudApi.Data;
using MongoCrudApi.Models;

namespace MongoCrudApi.Services;

public class GameService
{
    private readonly IMongoCollection<Game> _gamesCollection;

    public GameService(MongoDbContext context, IOptions<GameStoreDatabaseSettings> settings)
    {
        _gamesCollection = context.GetCollection<Game>(settings.Value.GamesCollectionName);
    }

    public async Task<List<Game>> GetAllAsync() =>
        await _gamesCollection.Find(_ => true).ToListAsync();

    public async Task<Game?> GetByIdAsync(string id) =>
        await _gamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Game newGame) =>
        await _gamesCollection.InsertOneAsync(newGame);

    public async Task UpdateAsync(string id, Game updatedGame) =>
        await _gamesCollection.ReplaceOneAsync(x => x.Id == id, updatedGame);

    public async Task RemoveAsync(string id) =>
        await _gamesCollection.DeleteOneAsync(x => x.Id == id);

    // Endpoint de Agregação / Consulta Avançada com Builders
    public async Task<List<GameStatsDto>> GetGamesStatisticsByGenreAsync()
    {
        var pipeline = _gamesCollection.Aggregate()
            .Group(
                g => g.Genre,
                group => new GameStatsDto
                {
                    Genre = group.Key,
                    TotalGames = group.Count(),
                    AveragePrice = (double)group.Average(x => x.Price),
                    AverageRating = group.Average(x => x.Rating)
                }
            )
            .SortByDescending(s => s.TotalGames);

        return await pipeline.ToListAsync();
    }
}

public class GameStatsDto
{
    public string Genre { get; set; } = string.Empty;
    public int TotalGames { get; set; }
    public double AveragePrice { get; set; }
    public double AverageRating { get; set; }
}