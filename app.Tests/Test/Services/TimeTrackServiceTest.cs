using app.Repository.Interfaces;
using app.Services;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Moq;

namespace app.Tests.Test.Services;

public class TimeTrackServiceTest
{
    private readonly Mock<ITimeTrackerRepo> _timeTrackerMock;
    private readonly ITimeTrackerService _service;

    public TimeTrackServiceTest()
    {
        _timeTrackerMock = new();
        _service = new TimeTrackerService(_timeTrackerMock.Object);
    }

    [Fact]
    public void Should_Create_TimeTrackService()
    {
        //Arrange
        var timeBank = MockTimebank.TimeBanks();
        
        _timeTrackerMock
            .Setup(repo => repo.AddTimeTracker(timeBank))
            .Returns(true);
        
        //Act
        bool result = _service.CreateTimeTracker(timeBank);
        
        //Assert
        Assert.True(result);
    }
}