namespace MongoCrudApi.Models;

public class GameStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string GamesCollectionName { get; set; } = string.Empty;
}