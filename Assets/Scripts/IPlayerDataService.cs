public interface IPlayerDataService
{
    int GetScore(string playerId);
    void SaveScore(string playerId, int newScore);
}