using app.Adapters.Interfaces;
using app.Repository.Interfaces;
using app.Services;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Moq;

namespace app.Tests.Test.Services;

public class TimeTrackServiceTest
{
     private readonly Mock<ITimeTrackerRepo> _timeTrackerRepoMock;
     private readonly Mock<IBaseAdapter> _baseAdapterMock;
     private readonly ITimeTrackerService _service;

     public TimeTrackServiceTest()
     {
         _timeTrackerRepoMock = new();
         _baseAdapterMock = new();
         _service = new TimeTrackerService(_timeTrackerRepoMock.Object, _baseAdapterMock.Object);
     }

     [Fact]
     private async Task Should_Create_TimeTrackService()
     {
         //Arrange
         var timeBankInput = MockTimebank.TimeBankInput();
         var timeBank = MockTimebank.TimeBanks();

         _baseAdapterMock
             .Setup(a => a.MapModelToEntity(timeBankInput))
             .Returns(timeBank);

         _timeTrackerRepoMock
             .Setup(repo => repo.AddTimeTracker(timeBank))
             .ReturnsAsync(true);

         //Act
         bool result = await _service.CreateTimeTracker(timeBankInput);

         //Assert
         Assert.True(result);
     }

     [Fact]
     private async Task Should_NotCreate_TimeTrackService()
     {
         //Arrange
         var timeBankInput = MockTimebank.TimeBankInput();
         var timeBank = MockTimebank.TimeBanks();

         _baseAdapterMock
             .Setup(a => a.MapModelToEntity(timeBankInput))
             .Returns(timeBank);

         _timeTrackerRepoMock
             .Setup(repo => repo.AddTimeTracker(timeBank))
             .ReturnsAsync(false);

         //Act
         bool result = await _service.CreateTimeTracker(timeBankInput);

         //Assert
         Assert.False(result);
     }
}