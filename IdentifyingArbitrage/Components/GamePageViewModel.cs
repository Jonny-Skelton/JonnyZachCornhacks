using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Components;

public class GamePageViewModel
{
    public List<Game> Games { get; set; }

    public GamePageViewModel()
    {
        // Initialize the list of games in the constructor
        Games = new List<Game>();
        LoadGames(); // Optionally load games from a data source
    }

    // Example method to load games (replace with your actual logic)
    private void LoadGames()
    {
        // Sample data - replace with your actual data retrieval logic
        Games.Add(new Game(new List<Team> { new Team("TeamA", -150), new Team("TeamB", 200) }));
        Games.Add(new Game(new List<Team> { new Team("TeamC", -120), new Team("TeamD", 150) }));
        // Add more games as needed
    }
}