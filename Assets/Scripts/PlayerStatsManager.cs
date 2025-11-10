using UnityEngine;

public class PlayerStatsManager
{
    private readonly IPlayerDataService _dataService;

    public PlayerStatsManager(IPlayerDataService dataService)
    {
        _dataService = dataService;
    }

    public int AddPoints(string playerId, int points)
    {
        int currentScore = _dataService.GetScore(playerId);
        int updatedScore = currentScore + points;
        _dataService.SaveScore(playerId, updatedScore);
        return updatedScore;
    }

    public bool HasReachedTarget(string playerId, int target)
    {
        int score = _dataService.GetScore(playerId);
        return score >= target;
    }
}