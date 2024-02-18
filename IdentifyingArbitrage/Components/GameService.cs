using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Components;

public class GameService
{
    private Game[] upcomingGames;

    public void SetUpcomingGames(Game[] games)
    {
        upcomingGames = games;
    }

    public Game[]? GetUpcomingGames()
    {
        return upcomingGames;
    }
}