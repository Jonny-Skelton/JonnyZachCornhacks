using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Components;

public class GameService
{
    private Game[] UpcomingGames;
    public Game SelectedGame { get; set; }

    public void SetUpcomingGames(Game[] games)
    {
        UpcomingGames = games;
    }

    public Game[]? GetUpcomingGames()
    {
        return UpcomingGames;
    }
}