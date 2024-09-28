using app.Controllers;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace app.Tests.Test.Controller;

public class TimeTrackerControllerTest
{
    private readonly Mock<ITimeTrackerService> _timeTrackerService;
    private readonly TimeTrackerController _controller;

    public TimeTrackerControllerTest()
    {
        _timeTrackerService = new Mock<ITimeTrackerService>();
        _controller = new TimeTrackerController(_timeTrackerService.Object);
    }

    [Fact]
    private void Should_Create_Time_Tracker()
    {
        //Arrange
        var timeBank = MockTimebank.TimeBanks();
        
        _timeTrackerService
            .Setup(s => s.CreateTimeTracker(timeBank))
            .Returns(true);
        
        //Act
        var postResult = _controller.CreateTimebanck(timeBank);
        
        //Assert
        Assert.True(postResult is OkObjectResult);
    }
}