using NUnit.Framework;
using Moq;

public class PlayerStatsManagerTests
{
    private Mock<IPlayerDataService> _mockService;
    private PlayerStatsManager _manager;

    [SetUp]
    public void SetUp()
    {
        // Create a Moq mock for the interface
        _mockService = new Mock<IPlayerDataService>();

        // Inject the mock into the class under test
        _manager = new PlayerStatsManager(_mockService.Object);
    }

    [Test]
    public void AddPoints_UpdatesScoreCorrectly()
    {
        // Arrange
        string playerId = "P1";
        _mockService.Setup(s => s.GetScore(playerId)).Returns(100);

        // Act
        int result = _manager.AddPoints(playerId, 50);

        // Assert
        Assert.AreEqual(150, result);

        // Verify that SaveScore was called with expected arguments
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