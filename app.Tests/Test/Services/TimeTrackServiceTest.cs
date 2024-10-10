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

     [Fact]
     private async Task Should_Get_TimeTrackService()
     {
         //Arrange
         DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
         var date = dateTimeOffset.ToString("d");
         
         var timeBankInput = MockTimebank.TimeBankInput();
         var timeBank = MockTimebank.TimeBanks();
         
         _timeTrackerRepoMock
             .Setup(repo => repo.GetTimeTracking(date))
             .ReturnsAsync(() => timeBank);
         
         _baseAdapterMock
             .Setup(a => a.MapEntityToModel(timeBank))
             .Returns(() => timeBankInput);
         
         //Act
         var result = await _service.GetTimeTrackersByDate(date);
         
         //Assert
         Assert.NotNull(result);
         Assert.Contains(date, result.TimeData);
         Assert.Equal(timeBankInput, result);
     }
     
     [Fact]
     private async Task Should_Get_Empty_TimeTrackService()
     {
         //Arrange
         var date = "2024-10-01";
         
         _timeTrackerRepoMock
             .Setup(repo => repo.GetTimeTracking(date))
             .ReturnsAsync(() => null);
         
         //Act
         var result = await _service.GetTimeTrackersByDate(date);
         
         //Assert
         Assert.Null(result);
     }
}