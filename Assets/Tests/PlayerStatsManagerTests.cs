using NUnit.Framework;
using Moq;

public class PlayerStatsManagerTests
{
    private Mock<IPlayerDataService> _mockService;
    private PlayerStatsManager _manager;

    [SetUp]
    public void SetUp()
    {
        _mockService = new Mock<IPlayerDataService>();

        _manager = new PlayerStatsManager(_mockService.Object);
    }

    [Test]
    public void AddPoints_UpdatesScoreCorrectly()
    {
        string playerId = "P1";
        _mockService.Setup(s => s.GetScore(playerId)).Returns(100);

        int result = _manager.AddPoints(playerId, 50);

        Assert.AreEqual(150, result);

        _mockService.Verify(s => s.SaveScore(playerId, 150), Times.Once);
    }

    [Test]
    public void HasReachedTarget_ReturnsTrue_WhenAboveTarget()
    {
        // Arrange
        string playerId = "P1";
        _mockService.Setup(s => s.GetScore(playerId)).Returns(200);

        // Act
        bool result = _manager.HasReachedTarget(playerId, 150);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void HasReachedTarget_ReturnsFalse_WhenBelowTarget()
    {
        // Arrange
        string playerId = "P2";
        _mockService.Setup(s => s.GetScore(playerId)).Returns(80);

        // Act
        bool result = _manager.HasReachedTarget(playerId, 100);

        // Assert
        Assert.IsFalse(result);
    }
}